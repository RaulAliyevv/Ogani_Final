using Ogani.Business.Dtos.BlogDtos;
using Ogani.Business.Services.Abstractions.Generic;
using Ogani.Core.Entities;

namespace Ogani.Business.Services.Abstractions;

public interface IBlogService : ICrudService<Blog, BlogCreateDto, BlogUpdateDto, BlogDto>
{
    Task<(bool Success, List<string> Errors)> CreateBlog(BlogCreateDto dto);
}
