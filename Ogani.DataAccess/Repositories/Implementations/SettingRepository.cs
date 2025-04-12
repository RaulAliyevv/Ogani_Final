using Ogani.Core.Entities;
using Ogani.DataAccess.Context;
using Ogani.DataAccess.Repositories.Implementations.Generic;

namespace Ogani.DataAccess.Repositories.Implementations;

internal class SettingRepository : Repository<Setting>, ISettingRepository
{
    private readonly AppDbContext _context;
    public SettingRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public string GetSettingByKey(string key)
    {
        return _context.Settings
                       .Where(s => s.Key == key)
                       .Select(s => s.Value)
                       .FirstOrDefault();
    }
}