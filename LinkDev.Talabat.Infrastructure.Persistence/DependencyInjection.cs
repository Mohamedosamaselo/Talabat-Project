using LinkDev.Talabat.Infrastructure.Persistence._Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Client;
using System.Runtime.CompilerServices;

namespace LinkDev.Talabat.Infrastructure.Persistence
{
    // static : we make extention Methods inside this Class 
    public static class DependencyInjection
    {
        // services  : DependencyInjection Container 
        public static IServiceCollection AddPersistenceService(this IServiceCollection services , IConfiguration configuration)
        {
            services.AddDbContext<StoreContext>((optionsBuilder) =>
            {
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("StoreContext"));
            }/*,contextLifetime : ServiceLifetime.Scoped,optionsLifetime : ServiceLifetime.Scoped*/);


            return services;

        }
    }
   

   
}