using Ogani.Core.Entities;
using Ogani.DataAccess.Context;
using Ogani.DataAccess.Repositories.Abstractions;
using Ogani.DataAccess.Repositories.Implementations.Generic;

namespace Ogani.DataAccess.Repositories.Implementations;

internal class SliderRightLeftRepository : Repository<SliderRightLeft>, ISliderRightLeftRepository
{
    public SliderRightLeftRepository(AppDbContext context) : base(context)
    {
    }
}
