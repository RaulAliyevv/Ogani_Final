using AutoMapper;
using Ogani.Business.Dtos.BlogDtos;
using Ogani.Business.Exceptions;
using Ogani.Business.Helpers;
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
        var result = FileHelper.ValidateImage(dto.ImageUrl);

        if (!result.IsSuccess)
        {
            errors.Add($" File Is not image or file size  200 mb");
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

    public async Task<BlogUpdateDto> BlogUpdateDto(int id)
    {
        var blog = await _blogRepository.GetAsync(id);

        if (blog == null)
        {
            throw new NotFoundException("Not Found");
        }

        var blopUpdateDto = new BlogUpdateDto {Id=blog.Id,Title=blog.Title, Text = blog.Text,Description = blog.Description ,ImageUrlPath= blog.ImageUrl };

        return blopUpdateDto;

    }

    public async Task<bool> Update(BlogUpdateDto dto)
    {
        if (dto == null)
            throw new NotFoundException("Blog not found");

        var existingBlog = await _blogRepository.GetAsync(dto.Id);
        if (existingBlog == null)
            throw new NotFoundException("Blog not found.");
            
        bool isSameData =
            existingBlog.Title == dto.Title &&
            existingBlog.Description == dto.Description &&
            existingBlog.Text == dto.Text &&
            dto.ImageUrl == null; 

        if (isSameData)
            return true;

        string? imagePath = existingBlog.ImageUrl;
        if (dto.ImageUrl != null)
        {
            var validationResult = FileHelper.ValidateImage(dto.ImageUrl);
            if (!validationResult.IsSuccess)
                throw new NotFoundException("File is not image və size is not 200MB.");

            imagePath = await _cloudinaryManager.FileCreateAsync(dto.ImageUrl);
        }

        existingBlog.Title = dto.Title;
        existingBlog.Description = dto.Description;
        existingBlog.Text = dto.Text;
        existingBlog.ImageUrl = imagePath;

         _blogRepository.Update(existingBlog);
        await _blogRepository.SaveChangesAsync();

        return true;
    }

    public async Task<bool> Delete(int id)
    {
        var blog  = await _blogRepository.GetAsync(id);
        if(blog == null) return false;

       await _blogRepository.Delete(blog);
        return true;
    }

}