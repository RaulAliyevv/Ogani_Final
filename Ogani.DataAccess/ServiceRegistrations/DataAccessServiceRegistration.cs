using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ogani.DataAccess.Context;
using Ogani.DataAccess.DataInitalizers;
using Ogani.DataAccess.Interceptors;
using Ogani.DataAccess.Repositories.Abstractions;
using Ogani.DataAccess.Repositories.Abstractions.Generic;
using Ogani.DataAccess.Repositories.Implementations;
using Ogani.DataAccess.Repositories.Implementations.Generic;

namespace Ogani.DataAccess.ServiceRegistrations
{
    public static class DataAccessServiceRegistration
    {
        public static IServiceCollection AddDataAccessServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("Default")));

            services.AddScoped<DbContextInitalizer>();

            AddRepositories(services);

            return services;
        }

        private static void AddRepositories(IServiceCollection services)
        {

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddScoped<ICategoryRepository, CategoryRepository>();

            services.AddScoped<IProductImageRepository, ProductImageRepository>();

            services.AddScoped<ISliderRepository, SliderRepository>();

            services.AddScoped<ISubscribeRepository, SubscribeRepository>();

            services.AddScoped<IBasketItemRepository, BasketItemRepository>();
            services.AddScoped<IWishlistItemRepository, WishlistItemRepository>();

            services.AddScoped<IBlogRepository, BlogRepository>();

            services.AddScoped<ISettingRepository, SettingRepository>();

            services.AddScoped<BaseAuditableInterceptor>();

        }
    }
}
