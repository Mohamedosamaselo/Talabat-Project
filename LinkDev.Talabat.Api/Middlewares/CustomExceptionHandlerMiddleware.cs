
using LinkDev.Talabat.Api.Controllers.Errors;
using LinkDev.Talabat.Api.Controllers.Exceptions;
using System.Net;
using System.Text.Json;

namespace LinkDev.Talabat.Api.Middlewares
{
    // Convension_Based 
    public class CustomExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<CustomExceptionHandlerMiddleware> _logger;
        private readonly IWebHostEnvironment _environment;

        public CustomExceptionHandlerMiddleware(RequestDelegate next, ILogger<CustomExceptionHandlerMiddleware> Logger, IWebHostEnvironment environment)
        {
            _next = next;
            _logger = Logger;
            _environment = environment;
        }


        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                // Logic Executed with the Requset

                await _next(httpContext);// Calling Delegate then Send Request 
                
                // Logic Executed with the Requset
               
                //if (httpContext.Response.StatusCode == (int)HttpStatusCode.NotFound)
                //{
                //    var response = new ApiResponse((int)HttpStatusCode.NotFound, $"the Requested EndPoint: {httpContext.Request.Path} is not Found");
                //    await httpContext.Response.WriteAsync(response.ToString());
                //};


            }
            catch (Exception ex)
            {
                ApiResponse response;

                switch (ex)
                {
                    case NotFoundException:
                        httpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                        httpContext.Response.ContentType = "application/josn";
                        response = new ApiResponse(404, ex.Message);

                        await httpContext.Response.WriteAsync(response.ToString());

                        break;

                    default:

                        // Development Mode
                        if (_environment.IsDevelopment())
                        {
                            _logger.LogError(ex, ex.Message);
                            response = new ApiExceptionResponse((int)HttpStatusCode.InternalServerError, ex.Message, ex.StackTrace?.ToString());
                        }
                        else
                        {
                            // Production Mode
                            /// Log Exception in DB | File (Text , json )
                            response = new ApiExceptionResponse((int)HttpStatusCode.InternalServerError);

                        }

                        break;
                }



                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                httpContext.Response.ContentType = "application/josn";

                await httpContext.Response.WriteAsync(response.ToString());

            }
        }
    }
}
