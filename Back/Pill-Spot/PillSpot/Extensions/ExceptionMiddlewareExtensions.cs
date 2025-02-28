using Contracts;
using Entities.ErrorModel;
using Entities.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Service.Contracts;
using System.Net;

namespace PillSpot.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this WebApplication app,
       ILogger<IServiceManager> logger)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        if (app.Environment.IsProduction())
                        {
                            await context.Response.WriteAsync(new ErrorDetails()
                            {
                                StatusCode = StatusCodes.Status500InternalServerError,
                                Message = "Internal server error",
                                Details = "An unexpected error occurred. Please try again later."
                            }.ToString());
                        }
                        else
                        {
                            context.Response.StatusCode = contextFeature.Error switch
                            {
                                NotFoundException => StatusCodes.Status404NotFound,
                                BadRequestException => StatusCodes.Status400BadRequest,
                                IOException => StatusCodes.Status409Conflict,
                                _ => StatusCodes.Status500InternalServerError
                            };

                            await context.Response.WriteAsync(new ErrorDetails()
                            {
                                StatusCode = context.Response.StatusCode,
                                Message = contextFeature.Error.Message,
                                Details = contextFeature.Error.ToString()
                            }.ToString());
                        }

                    }
                });
            });
        }
    }
}
