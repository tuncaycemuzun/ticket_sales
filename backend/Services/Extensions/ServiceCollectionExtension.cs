using Core.Services;
using Microsoft.Extensions.DependencyInjection;
using Services.Concrete;

namespace Services.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection ServiceLayerServiceCollection(this IServiceCollection services)
        {
            services.AddSingleton<IAuthService, AuthService>();
            services.AddSingleton<ITicketService, TicketService>();
            services.AddSingleton<ITicketTypeService, TicketTypeService>();
            return services;
        }
    }
}
