using Microsoft.AspNetCore.Http;

namespace Ogani.Business.Services.Abstractions;

public interface ICloudinaryManager
{
    Task<string> FileCreateAsync(IFormFile file);
    Task<bool> FileDeleteAsync(string filePath);
    Task<string> VideoUploadAsync(IFormFile file);
    Task<bool> VideoDeleteAsync(string filePath);
}
