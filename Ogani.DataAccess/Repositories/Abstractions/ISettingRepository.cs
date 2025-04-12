using Ogani.Core.Entities;
using Ogani.DataAccess.Repositories.Abstractions.Generic;

public interface ISettingRepository : IRepository<Setting>
{
    string GetSettingByKey(string key);
}
