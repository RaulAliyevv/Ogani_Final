using Ogani.Business.Dtos.HomeDtos;
using Ogani.Business.Dtos.ProductDtos;
using Ogani.Business.Services.Abstractions;
using Ogani.Business.UIService.Abstractions;

namespace Ogani.Business.UIService.Implementations
{
    internal class ShopService : IShopService
    {
        private readonly IProductService _productService;

        public ShopService(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<List<ProductDto>> GetProducts()
        {
            var products = await _productService.GetAllAsync();

            return products;
        }

        public async Task<ShopDto> GetShop()
        {
            var products = await GetProducts();

            var shopDto = new ShopDto
            {
                Products = products
            };

            return shopDto;
        }

        public async Task<ShopDto> GetShop(string? search, string? sort, int? categoryId = null)
        {
            var products = await _productService.GetAllAsync();

            if (!string.IsNullOrWhiteSpace(search))
            {
                products = products
                    .Where(p => p.Name.Contains(search, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            if (categoryId.HasValue)
            {
                products = products
                    .Where(p => p.CategoryId == categoryId.Value)
                    .ToList();
            }

            products = sort switch
            {
                "az" => products.OrderBy(p => p.Name).ToList(),
                "za" => products.OrderByDescending(p => p.Name).ToList(),
                "priceLowHigh" => products.OrderBy(p => p.Price).ToList(),
                "priceHighLow" => products.OrderByDescending(p => p.Price).ToList(),
                _ => products
            };

            return new ShopDto
            {
                Products = products
            };
        }
    }
}
