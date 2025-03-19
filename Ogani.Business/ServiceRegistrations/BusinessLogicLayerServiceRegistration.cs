using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Ogani.Business.ServiceRegistrations
{
    public static class BusinessLogicLayerServiceRegistration
    {

        public static IServiceCollection AddBllServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

           


            return services;
        }
    }
}
