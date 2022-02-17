using Core.Services;
using Microsoft.Extensions.DependencyInjection;
using Services.Concrete;

namespace Services.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection ServiceLayerServiceCollection(this IServiceCollection services)
        {
            services.AddSingleton<IUserService, UserService>();
            return services;
        }
    }
}
