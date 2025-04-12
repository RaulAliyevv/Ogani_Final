using Ogani.Core.Entities;
using Ogani.DataAccess.Context;
using Ogani.DataAccess.Repositories.Implementations.Generic;

namespace Ogani.DataAccess.Repositories.Implementations;

internal class BlogRepository : Repository<Blog>, IBlogRepository
{
    public BlogRepository(AppDbContext context) : base(context)
    {
    }
}
