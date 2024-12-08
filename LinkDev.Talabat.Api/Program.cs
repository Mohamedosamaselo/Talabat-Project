
using LinkDev.Talabat.Api.Extentions;
using LinkDev.Talabat.Core.Domain.Contracts.Persistence.DbIntializers;
using LinkDev.Talabat.Infrastructure.Persistence;
using LinkDev.Talabat.Infrastructure.Persistence._Data;
using Microsoft.EntityFrameworkCore;

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
