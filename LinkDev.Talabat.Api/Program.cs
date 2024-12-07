
using LinkDev.Talabat.Infrastructure.Persistence;
using LinkDev.Talabat.Infrastructure.Persistence._Data;
using Microsoft.AspNetCore.Mvc;
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

            #region Update Database or Apply ANy Pending Migrations 

            using var scope = app.Services.CreateAsyncScope();          //1.Create Scoope
            var services = scope.ServiceProvider;                       //2.resolve any dependancy from the Request  

            var dbContext = services.GetRequiredService<StoreContext>();// 3.Get  Services from storedbContext
            // Ask RunTime enviroment for an object from "StoreContext" Explicilty

            var loggerFactory = services.GetRequiredService<ILoggerFactory>();// Ask for object from LoggerFactory Services 
            ///var FactoryLogger = services.GetRequiredService(typeof(ILoggerFactory));
            ///var Logger = services.GetRequiredService<ILogger<Program>>();// ask for object of logger on level program only 

            try
            {
                var PendingMigrations = dbContext.Database.GetPendingMigrations();

                if (PendingMigrations.Any())
                    await dbContext.Database.MigrateAsync();    //Apply any Pending Migrations  {Update-Database} 

            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<Program>();// Logger factory use abstract Design Pattern 
                logger.LogError(ex, "an error has been occured during applying the Migrations .");

            }

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
