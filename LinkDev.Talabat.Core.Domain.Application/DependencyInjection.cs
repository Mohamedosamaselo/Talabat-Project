using LinkDev.Talabat.Core.Application.Abstraction.Services;
using LinkDev.Talabat.Core.Application.Mapping;
using LinkDev.Talabat.Core.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace LinkDev.Talabat.Core.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            ///1. services.AddAutoMapper(mapper => mapper.AddProfile(new MappingProfile() ));// hena ana b create object by myself  wmomken  send any argyment 
            ///2. services.AddAutoMapper(mapper => mapper.AddProfile<MappingProfile>());     // hena ana b create object by using Paramterless Constructor
            ///3. services.AddAutoMapper(typeof(MappingProfile01) , typeof(MappingProfile02));// hena ana b create object by using Paramterless Constructor , w momkn register akter mn mapping Profile
            ///4. services.AddAutoMapper(typeof(MappingProfile).Assembly);                   // hena ana ba2olo ro7 5od assembly w dawr 3ala ay class inherit from class Profile 
            ///4. services.AddAutoMapper(typeof(Assembly information).Assembly);             // hena ana 3amlt class 3l4an aklm beh l assembly bta3 l project w hewa [ AssemblyInformation ]

            services.AddAutoMapper(typeof(MappingProfile));//clr create object from class Mapping Profile Depending on Parameterless Constructor 

            //services.AddScoped(typeof(IProductService), typeof(ProductService));// i don't need to ask run time enviroment to register service for DI Container as i make intialization in service Manager 
                
            services.AddScoped(typeof(IServiceManager) , typeof(ServiceManager));


            return services;
        }
    }
}
