using GlobalExceptionHandler.WebApi;
using Microsoft.AspNetCore.Builder;
using Newtonsoft.Json;

namespace ElevaEducacao.Extension
{
    public static class ErrorHandlingExtensions
    {
        public static void UseExceptionHandlers(this IApplicationBuilder app, string defaultErrorMessage = "UNHANDLED_EXCEPTION")
        {
            app.UseGlobalExceptionHandler(x => {
                x.ContentType = "application/json";
                x.ResponseBody(s => JsonConvert.SerializeObject(new
                {
                    success = false,
                    errors = new[] { defaultErrorMessage }
                }));
            });
        }
    }

    
}
