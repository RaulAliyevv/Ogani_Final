using Ogani.Business.Dtos.HomeDtos;

namespace Ogani.Business.UIService.Abstracts
{
    public interface IHomeService
    {
        Task<HomeDto> GetHomeViewModelAsync();
    }
}
