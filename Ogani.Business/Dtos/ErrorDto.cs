using Ogani.Business.Dtos.Base;

namespace Ogani.Business.Dtos;

public class ErrorDto : IDto
{
    public string Name { get; set; } = "Error";
    public string Message { get; set; } = null!;
    public int StatusCode { get; set; }
}
