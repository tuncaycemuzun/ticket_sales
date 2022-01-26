using Core.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
