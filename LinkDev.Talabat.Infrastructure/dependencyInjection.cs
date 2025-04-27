using LinkDev.Talabat.Core.Domain.Contracts.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.Talabat.Infrastructure
{
    public static class dependencyInjection
    {
        public static IServiceCollection AddInfrastructureService (this IServiceCollection services , IConfiguration configuration  )
        {
            services.AddScoped(typeof(IConnectionMultiplexer), (_) =>
            {
                var connectionString = configuration.GetConnectionString("Redis");
                var connectionMultiplexer = ConnectionMultiplexer.Connect(connectionString!);
                return connectionMultiplexer;
            });

            services.AddScoped(typeof(IBasketRepository), typeof(BasketRepository));

            return services; 
        }

    }
}
