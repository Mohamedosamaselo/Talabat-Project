
using LinkDev.Talabat.Api.Controllers.Errors;
using LinkDev.Talabat.Api.Extentions;
using LinkDev.Talabat.Api.Middlewares;
using LinkDev.Talabat.Api.Services;
using LinkDev.Talabat.Core.Application;
using LinkDev.Talabat.Core.Application.Abstraction.Services;
using LinkDev.Talabat.Infrastructure;
using LinkDev.Talabat.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;

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

          
            webApplicationBuilder.Services.AddControllers()
                                          .ConfigureApiBehaviorOptions(options =>
                                          {
                                              options.SuppressModelStateInvalidFilter = false;     // actionFilter 
                                              options.InvalidModelStateResponseFactory = (ActionContext) =>
                                              {
                                                  var errors = ActionContext.ModelState.Where(p => p.Value!.Errors.Count > 0)
                                                                         .SelectMany(p => p.Value!.Errors)
                                                                         .Select(E => E.ErrorMessage);


                                                  return new BadRequestObjectResult(new ApiValidationErrorResponse()
                                                  {
                                                      Errors = errors
                                                  });

                                              };
                                          })
                                          .AddApplicationPart(typeof(AssembleyInformation).Assembly);//to add apart of another application 

            webApplicationBuilder.Services.Configure<ApiBehaviorOptions>(options =>
            {

                options.SuppressModelStateInvalidFilter = false;// actionFilter 
                options.InvalidModelStateResponseFactory = (ActionContext) =>
                {
                    var errors = ActionContext.ModelState.Where(p => p.Value!.Errors.Count > 0)
                                           .SelectMany(p => p.Value!.Errors)
                                           .Select(E => E.ErrorMessage);


                    return new BadRequestObjectResult(new ApiValidationErrorResponse()
                    {
                        Errors = errors
                    });

                };
            });


            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            webApplicationBuilder.Services.AddEndpointsApiExplorer().AddSwaggerGen();

            // Configure Service of Persistence Layer 
            webApplicationBuilder.Services.AddPersistenceService(webApplicationBuilder.Configuration);
            // Configure Service of Persistence Layer 
            webApplicationBuilder.Services.AddInfrastructureService(webApplicationBuilder.Configuration);
            // Configure Service of Application Layer 
            webApplicationBuilder.Services.AddApplicationServices();



            webApplicationBuilder.Services.AddHttpContextAccessor();// this Method Register More than Services  
            webApplicationBuilder.Services.AddScoped(typeof(ILoggedInUserService), typeof(LoggedInUserServices));

            #endregion

            var app = webApplicationBuilder.Build();

            #region Databases Initializations 

            await app.InitializeStoreContextAsync();

            #endregion

            #region Configure Kestrell MiddleWare

            app.UseMiddleware<CustomExceptionHandlerMiddleware>();// Calling Custom MiddleWare 

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {

                app.UseSwagger();
                app.UseSwaggerUI();

                //app.UseDeveloperExceptionPage();// .Net 5 by default it has been Used to show exceptionPage ;
            }

            app.UseStatusCodePagesWithReExecute("/Errors/{0}");

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseStaticFiles();

            app.MapControllers();

            #endregion

            app.Run();

        }
    }
}
