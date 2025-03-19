using Microsoft.Extensions.DependencyInjection;
using Ogani.Business.Services.Abstractions;
using Ogani.Business.Services.Implementations;
using System.Reflection;

namespace Ogani.Business.ServiceRegistrations;

public static class BusinessLogicLayerServiceRegistration
{

    public static IServiceCollection AddBllServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IProductCategoryService, ProductCategoryService>();
        services.AddScoped<IProductImageService, ProductImageService>();

        services.AddScoped<ICategoryService, CategoryService>();

        return services;
    }
}
