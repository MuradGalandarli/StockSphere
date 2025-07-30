using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.Diagnostics;
using System.Net;
using System.Net.Mime;
using System.Text.Json;

namespace StockSphere.Api.Extensions
{
    public static class ConfigureExtensionHandler
    {
        public static void ConfigureExceptionHandler<T>(this WebApplication webApplication, ILogger<T> logger)
        {
            webApplication.UseExceptionHandler(builder =>
            {
                builder.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = MediaTypeNames.Application.Json;

                    var contextFeatures = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeatures != null)
                    {
                        logger.LogError(contextFeatures.Error.Message+"-------------------------------------------");
                    }
                    await context.Response.WriteAsync(JsonSerializer.Serialize(new
                    {
                        StatusCode = context.Response.StatusCode,
                        Message = contextFeatures.Error.Message,
                        Title = "Xeta alindi"
                    }
                        ));
                });
            });
        }
    }
}
