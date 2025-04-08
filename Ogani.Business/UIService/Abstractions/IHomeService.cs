using Ogani.Business.Dtos.HomeDtos;
using Ogani.Business.Dtos.Subscribes;

namespace Ogani.Business.UIService.Abstracts
{
    public interface IHomeService
    {
        Task<HomeDto> GetHomeViewModelAsync();
        Task<DetailDto> GetDetail(int id);
        Task<bool> CreateSubcribeAsync(SubscribeCreateDto dto);
    }
}
