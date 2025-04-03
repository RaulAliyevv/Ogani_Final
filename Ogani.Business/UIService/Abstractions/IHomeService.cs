using Ogani.Business.Dtos.HomeDtos;

namespace Ogani.Business.UIService.Abstracts
{
    public interface IHomeService
    {
        Task<HomeDto> GetHomeViewModelAsync();
        Task<DetailDto> GetDetail(int id);
    }
}
