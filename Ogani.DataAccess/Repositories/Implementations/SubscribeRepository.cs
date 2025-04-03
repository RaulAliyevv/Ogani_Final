using Ogani.Core.Entities;
using Ogani.DataAccess.Context;
using Ogani.DataAccess.Repositories.Implementations.Generic;

namespace Ogani.DataAccess.Repositories.Implementations;

internal class SubscribeRepository : Repository<Subscribe>, ISubscribeRepository
{
    public SubscribeRepository(AppDbContext context) : base(context)
    {
    }
}