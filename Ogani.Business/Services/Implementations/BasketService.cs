using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Ogani.Business.Exceptions;
using Ogani.Business.Services.Abstractions;
using Ogani.Core.Entities.Base;
using Ogani.DataAccess.Repositories.Abstractions;
using System.Security.Claims;

namespace Ogani.Business.Services.Implementations
{
    public class BasketService : IBasketService
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
                    basket = JsonConvert.DeserializeObject<List<BasketCookieItem>>(cookieData)!;
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
                    HttpOnly = true
                });
            }

            return true;
        }

        public async Task<List<BasketItemDto>> GetBasketAsync()
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
                        ProductPrice = b.Product.Price
                    })
                    .ToListAsync();

                return items;
            }
            else
            {
                // Login olmayıbsa — cookie-dən oxu
                var cookie = _httpContextAccessor.HttpContext.Request.Cookies["basket"];

                if (cookie == null)
                    return new List<BasketItemDto>();

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
                        img = product.IsMainPicture

                    });
                }

                return result;
            }
        }


        public class BasketItemDto
        {
            public string? img { get; set; }
            public int ProductId { get; set; }
            public int Count { get; set; }
            public string ProductName { get; set; } = null!;
            public decimal ProductPrice { get; set; }
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
