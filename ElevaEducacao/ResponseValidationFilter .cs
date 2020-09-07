using ElevaEducacao.Infra.CrossCutting.NotificationPattern;
using ElevaEducacao.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElevaEducacao
{
    public class ResponseValidationFilter : IAsyncResultFilter
    {
        private readonly INotificationContext _notificationContext;
        public ResponseValidationFilter(INotificationContext notificationContext)
        {
            _notificationContext = notificationContext;
        }

        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            var apiResponse = ApiResponseContract.From(_notificationContext.Notifications);

            if (context.Result is OkObjectResult && !apiResponse.Success)
            {
                var json = JsonConvert.SerializeObject(apiResponse.ToJson(), new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
                    DateTimeZoneHandling = DateTimeZoneHandling.Utc
                });

                context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                context.HttpContext.Response.ContentType = "application/json";
                await context.HttpContext.Response.WriteAsync(json);
            }

            if (!context.HttpContext.Response.HasStarted)
                await next();
        }
    }
}
