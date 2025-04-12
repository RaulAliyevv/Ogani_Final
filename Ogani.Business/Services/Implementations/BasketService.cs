using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Ogani.Business.Dtos;
using Ogani.Business.Dtos.BasketDtos;
using Ogani.Business.Exceptions;
using Ogani.Business.Services.Abstractions;
using Ogani.Core.Entities;
using Ogani.Core.Entities.Base;
using Ogani.DataAccess.Repositories.Abstractions;
using System.Security.Claims;

namespace Ogani.Business.Services.Implementations
{
    public partial class BasketService : IBasketService
    {
        private readonly IProductService _productService;
        private readonly IBasketItemRepository _basketItemRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public BasketService(IProductService productService, IBasketItemRepository basketItemRepository, IHttpContextAccessor httpContextAccessor)
        {
            _productService = productService;
            _basketItemRepository = basketItemRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<bool> AddToBasketAsync(int id, int count = 1)
        {
            var product = await _productService.GetAsync(id);
            if (product == null)
                throw new NotFoundException("Product not found!");

            var user = _httpContextAccessor.HttpContext!.User;
            var isAuthenticated = user.Identity != null && user.Identity.IsAuthenticated;

            if (isAuthenticated)
            {
                string userId = user.FindFirst(ClaimTypes.NameIdentifier)!.Value;

                var existingItem = await _basketItemRepository.GetAsync(x => x.ProductId == id && x.AppUserId == userId);
                if (existingItem != null)
                {
                    existingItem.Count += count;
                    _basketItemRepository.Update(existingItem);
                }
                else
                {
                    BasketItem basketItem = new BasketItem
                    {
                        AppUserId = userId,
                        ProductId = id,
                        Count = count
                    };
                    await _basketItemRepository.CreateAsync(basketItem);
                }

                await _basketItemRepository.SaveChangesAsync();
            }
            else
            {
                var cookies = _httpContextAccessor.HttpContext.Response.Cookies;
                var requestCookies = _httpContextAccessor.HttpContext.Request.Cookies;

                List<BasketCookieItem> basket = new();

                string? cookieData = requestCookies["basket"];
                if (!string.IsNullOrEmpty(cookieData))
                {
                    basket = JsonConvert.DeserializeObject<List<BasketCookieItem>>(cookieData) ?? new List<BasketCookieItem>();
                }

                var item = basket.FirstOrDefault(x => x.ProductId == id);
                if (item != null)
                {
                    item.Count += count;
                }
                else
                {
                    basket.Add(new BasketCookieItem
                    {
                        ProductId = id,
                        Count = count
                    });
                }

                string updatedCookie = JsonConvert.SerializeObject(basket);
                cookies.Append("basket", updatedCookie, new CookieOptions
                {
                    Expires = DateTime.Now.AddDays(14),
                    HttpOnly = false, 
                    Secure = false     
                });
            }

            return true;
        }


        public async Task<CardDto> GetBasketAsync()
        {
            var user = _httpContextAccessor.HttpContext.User;

            if (user.Identity is not null && user.Identity.IsAuthenticated)
            {
                var userId = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                var itemsQuery = _basketItemRepository.GetFilter(
                    expression: b => b.AppUserId == userId,
                    include: query => query.Include(b => b.Product),
                    asNotTracking: true
                );

                

                var items = await itemsQuery
                    .Select(b => new BasketItemDto
                    {
                        ProductId = b.ProductId,
                        Count = b.Count,
                        ProductName = b.Product.Name,
                        ProductPrice = b.Product.Price,
                        img = b.Product.IsMainPicture,
                        TotalProductPrice = b.Count * b.Product.Price,

                    })
                    .ToListAsync();

                var card = new CardDto
                {
                    Prroduct =items,
                    Count =  await GetBasketCountAsync(),
                    TotalAmount = await GetBasketTotalAsync()
                };

                return card;
            }
            else
            {
                var cookie = _httpContextAccessor.HttpContext.Request.Cookies["basket"];

                if (cookie == null)
                    return new CardDto();

                var items = JsonConvert.DeserializeObject<List<BasketCookieItemDto>>(cookie);

                var result = new List<BasketItemDto>();

                foreach (var item in items)
                {
                    var product = await _productService.GetAsync(item.ProductId);
                    if (product == null) continue;

                    result.Add(new BasketItemDto
                    {
                        ProductId = product.Id,
                        Count = item.Count,
                        ProductName = product.Name,
                        ProductPrice = product.Price,
                        img = product.IsMainPicture,
                        TotalProductPrice = product.Price * item.Count

                    });
                }
                var card = new CardDto
                {
                    Prroduct = result,
                    Count = await GetBasketCountAsync(),
                    TotalAmount = await GetBasketTotalAsync()
                };


                return card;
            }


        }

        public async Task<bool> DecreaseFromBasketAsync(int productId)
        {
            var user = _httpContextAccessor.HttpContext!.User;
            var isAuthenticated = user.Identity != null && user.Identity.IsAuthenticated;

            if (isAuthenticated)
            {
                string userId = user.FindFirst(ClaimTypes.NameIdentifier)!.Value;

                var item = await _basketItemRepository.GetAsync(x => x.ProductId == productId && x.AppUserId == userId);
                if (item == null) return false;

                if (item.Count > 1)
                {
                    item.Count--;
                    _basketItemRepository.Update(item);
                }
                else
                {
                   await _basketItemRepository.Delete(item);
                }

                await _basketItemRepository.SaveChangesAsync();
            }
            else
            {
                var requestCookies = _httpContextAccessor.HttpContext.Request.Cookies;
                var responseCookies = _httpContextAccessor.HttpContext.Response.Cookies;

                string? cookieData = requestCookies["basket"];
                if (string.IsNullOrEmpty(cookieData)) return false;

                var basket = JsonConvert.DeserializeObject<List<BasketCookieItem>>(cookieData)!;
                var item = basket.FirstOrDefault(x => x.ProductId == productId);
                if (item == null) return false;

                if (item.Count > 1)
                {
                    item.Count--;
                }
                else
                {
                    basket.Remove(item);
                }

                string updatedCookie = JsonConvert.SerializeObject(basket);
                responseCookies.Append("basket", updatedCookie, new CookieOptions
                {
                    Expires = DateTime.Now.AddDays(14),
                    HttpOnly = true
                });
            }

            return true;
        }


        public async Task<int> GetBasketCountAsync()
        {
            var userId = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var basketItems = new List<BasketItem>();

            if (userId is not null)
            {
                basketItems = await _basketItemRepository
                    .GetFilter(x => x.AppUserId == userId)
                    .ToListAsync();
            }
            else
            {
                var cookie = _httpContextAccessor.HttpContext?.Request.Cookies["basket"];
                if (!string.IsNullOrWhiteSpace(cookie))
                {
                    var cookieItems = JsonConvert.DeserializeObject<List<BasketCookieItem>>(cookie);
                    basketItems = cookieItems.Select(x => new BasketItem
                    {
                        ProductId = x.ProductId,
                        Count = x.Count
                    }).ToList();
                }
            }

            return basketItems.Sum(x => x.Count);
        }



        public async Task<decimal> GetBasketTotalAsync()
        {
            decimal totalPrice = 0;

            var user = _httpContextAccessor.HttpContext.User;

            if (user.Identity is not null && user.Identity.IsAuthenticated)
            {
                var userId = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                var itemsQuery = _basketItemRepository.GetFilter(
                    expression: b => b.AppUserId == userId,
                    include: query => query.Include(b => b.Product),
                    asNotTracking: true
                );

                var items = await itemsQuery.ToListAsync();

                totalPrice = items.Sum(b => b.Count * b.Product.Price);
            }
            else
            {
                var cookie = _httpContextAccessor.HttpContext.Request.Cookies["basket"];

                if (cookie != null)
                {
                    var items = JsonConvert.DeserializeObject<List<BasketCookieItem>>(cookie);
                    foreach (var item in items)
                    {
                        var product = await _productService.GetAsync(item.ProductId);
                        if (product != null)
                        {
                            totalPrice += item.Count * product.Price;
                        }
                    }
                }
            }

            return totalPrice;
        }

        public class BasketCookieItemDto
        {

            public string? img { get; set; }

            public int ProductId { get; set; }
            public int Count { get; set; }
        }


        public class BasketCookieItem
        {
            public int ProductId { get; set; }
            public int Count { get; set; }
        }
    }
}
