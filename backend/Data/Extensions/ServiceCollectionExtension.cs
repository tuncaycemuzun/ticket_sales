using Core.Abstract;
using Data.Repositories;
using Data.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Data.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection DataLayerServiceCollection(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddSingleton<IAuthRepository, UserRepository>();
            services.AddSingleton<ITokenRepository, TokenRepository>();
            services.AddSingleton<ITicketRepository, TicketRepository>();
            services.AddSingleton<ITicketTypeRepository, TicketTypeRepository>();

            return services.Configure<MongoDbSettings>(options =>
            {
                options.ConnectionString = configuration
                    .GetSection(nameof(MongoDbSettings) + ":" + MongoDbSettings.ConnectionStringValue).Value;
                options.Database = configuration
                    .GetSection(nameof(MongoDbSettings) + ":" + MongoDbSettings.DatabaseValue).Value;
            });
        }
    }
}
