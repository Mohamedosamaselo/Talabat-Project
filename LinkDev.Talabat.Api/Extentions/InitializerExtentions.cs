using LinkDev.Talabat.Core.Domain.Contracts.Persistence.DbIntializers;

namespace LinkDev.Talabat.Api.Extentions
{
    public static class InitializerExtentions
    {
        public static async Task<WebApplication> InitializeStoreContextAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateAsyncScope();                       // 1.Create Scoope
           
            var services = scope.ServiceProvider;                                               // 2.resolve any dependancy from the Request  

            var storeContextIntializer = services.GetRequiredService<IStoreContextIntializer>();// 3. Return Service Object OfType storeContextInitializer
                                                                                                // Ask RunTime enviroment for an object from "StoreContext" Explicilty [3 Steps]

            var loggerFactory = services.GetRequiredService<ILoggerFactory>();                  // Ask for object from LoggerFactory Services 


            try
            {
                await storeContextIntializer.InitializeAsync(); // UpdateDatabase [Apply Any Pending Migrations] 
                await storeContextIntializer.SeedAsync();       // DataSeeding
            }
            catch (Exception ex)
            {
                // Logging Exceptions
                var logger = loggerFactory.CreateLogger<Program>();                // Logger factory use abstract Design Pattern 
                logger.LogError(ex, "an error has been occured during applying the Migrations .");
            }



            return app;
        }
    }
}
