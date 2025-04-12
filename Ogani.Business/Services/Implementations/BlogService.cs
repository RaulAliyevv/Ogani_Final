using AutoMapper;
using Ogani.Business.Dtos.BlogDtos;
using Ogani.Business.Services.Abstractions;
using Ogani.Business.Services.Implementations.Generic;
using Ogani.Core.Entities;

namespace Ogani.Business.Services.Implementations;

public class BlogService : CrudService<Blog, BlogCreateDto, BlogUpdateDto, BlogDto>, IBlogService
{
    private readonly ICloudinaryManager _cloudinaryManager;
    private readonly IBlogRepository _blogRepository;
    public BlogService(IBlogRepository repository, IMapper mapper, ICloudinaryManager cloudinaryManager) : base(repository, mapper)
    {
        _cloudinaryManager = cloudinaryManager;
        _blogRepository = repository;
    }


    public async Task<(bool Success, List<string> Errors)> CreateBlog(BlogCreateDto dto)
    {
        var errors = new List<string>();

        if (dto == null)
        {
            errors.Add("Blog data is null.");
            return (false, errors);

        }

        if (dto.ImageUrl is null)
        {
            errors.Add($" IMAGE Is requared");
            return (false, errors);
        }


        if (dto.Text is null)
        {
            errors.Add($" Text Is requared");
            return (false, errors);
        }
        if (dto.Description is null)
        {
            errors.Add($" Description Is requared");
            return (false, errors);
        }

        var imagePath = await _cloudinaryManager.FileCreateAsync(dto.ImageUrl);


        var model = new Blog
        {
            Text = dto.Text,
            Description = dto.Description,
            ImageUrl = imagePath,
            Title = dto.Title
        };

        await _blogRepository.CreateAsync(model);

        return (true, new List<string>());

    }
}