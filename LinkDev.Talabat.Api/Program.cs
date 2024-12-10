
using LinkDev.Talabat.Api.Extentions;
using LinkDev.Talabat.Api.Services;
using LinkDev.Talabat.Core.Application.Abstraction.Services;
using LinkDev.Talabat.Infrastructure.Persistence;

namespace LinkDev.Talabat.Api
{
    public class Program
    {
        // EntryPoint of Application  
        public static async Task Main(string[] args)
        {
            var webApplicationBuilder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            #region Configure Services

            webApplicationBuilder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

            webApplicationBuilder.Services.AddEndpointsApiExplorer().AddSwaggerGen();

            webApplicationBuilder.Services.AddPersistenceService(webApplicationBuilder.Configuration);// Configure Service of Persistence Layer 

            webApplicationBuilder.Services.AddHttpContextAccessor();// this Method Register More than Services  
            webApplicationBuilder.Services.AddScoped(typeof(ILoggedInUserService) ,typeof(LoggedInUserServices));

            #endregion

            var app = webApplicationBuilder.Build();

            #region Databases Initializations 

            await app.InitializeStoreContextAsync();

            #endregion


            #region Configure Kestrell MiddleWare


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            #endregion

            app.Run();

        }
    }
}
