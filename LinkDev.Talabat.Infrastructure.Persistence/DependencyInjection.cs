using LinkDev.Talabat.Core.Domain.Contracts.Persistence;
using LinkDev.Talabat.Core.Domain.Contracts.Persistence.DbIntializers;
using LinkDev.Talabat.Infrastructure.Persistence._Data;
using LinkDev.Talabat.Infrastructure.Persistence._Data.Interceptors;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace LinkDev.Talabat.Infrastructure.Persistence
{
    // static : we make extention Methods inside this Class 
    public static class DependencyInjection
    {
        // services  : DependencyInjection Container 
        public static IServiceCollection AddPersistenceService(this IServiceCollection services, IConfiguration configuration)
        {
          
            services.AddDbContext<StoreContext>((optionsBuilder) =>
            {
                optionsBuilder.UseLazyLoadingProxies() // to allow Lazyloading Mode 
                              .UseSqlServer(configuration.GetConnectionString("StoreContext"));
            } /*,contextLifetime:ServiceLifetime.Scoped , optionsLifetime : ServiceLifetime.Scoped*/);// bydefault servicelife time is scooped


            services.AddScoped(typeof(IStoreContextIntializer), typeof(StoreContextIntializer));// Allow DI To StoreContextIntializer Class 

            services.AddScoped(typeof(ISaveChangesInterceptor), typeof(CustomSaveChangesInterceptor));

            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork.UnitOfWork));


            return services;
        }
    }



}