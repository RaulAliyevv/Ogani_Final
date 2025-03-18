using Ogani.Core.Entities;
using Ogani.DataAccess.Context;
using Ogani.DataAccess.Repositories.Abstractions;
using Ogani.DataAccess.Repositories.Implementations.Generic;

namespace Ogani.DataAccess.Repositories.Implementations
{
    internal class ProductCategoryRepository : Repository<ProductCategory>, IProductCategoryRepository
    {
        public ProductCategoryRepository(AppDbContext context) : base(context)
        {
        }
    }
}
