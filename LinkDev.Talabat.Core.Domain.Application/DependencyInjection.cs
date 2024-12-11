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
            ///services.AddAutoMapper(mapper => mapper.AddProfile(new MappingProfile()));// i create object from class MApping Profile and can send and argument as a parameter if parameterless consructor take any parameters 
            ///services.AddAutoMapper(mapper => mapper.AddProfile<MappingProfile>());// Creating object from class mapping profile using parameterless constructor
            ///services.AddAutoMapper(typeof(AssemblyInformation).Assembly);// take assembly and take any class that inherit from class MappingProfile
            
            services.AddAutoMapper(typeof(MappingProfile));//clr create object from class Mapping Profile Depending on Parameterless Constructor 

            //services.AddScoped(typeof(IProductService), typeof(ProductService));// i don't need to ask run time enviroment to register service for DI Container as i make intialization in service Manager 
                
            services.AddScoped(typeof(IServiceManager) , typeof(ServiceManager));

            return services;
        }
    }
}
