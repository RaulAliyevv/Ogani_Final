using Ogani.Core.Entities.Base;
using Ogani.DataAccess.Context;
using Ogani.DataAccess.Repositories.Abstractions;
using Ogani.DataAccess.Repositories.Implementations.Generic;

namespace Ogani.DataAccess.Repositories.Implementations;

internal class BasketItemRepository : Repository<BasketItem>, IBasketItemRepository
{
    public BasketItemRepository(AppDbContext context) : base(context)
    {
    }
}
