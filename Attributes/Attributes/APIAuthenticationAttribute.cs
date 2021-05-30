using Domain.Models.SecurityDetails;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class APIAuthenticationAttribute : Attribute, IAsyncActionFilter
    {
        private const string ApiKetHeaderName = "ApiKey";
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var configuration = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();
            var apiKeys = configuration.GetSection("SecurityDetails").Get<SecurityDetails>();

            if (!context.HttpContext.Request.Headers.TryGetValue(ApiKetHeaderName, out var patentialApiKey))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            if (apiKeys.ApiKey != patentialApiKey)
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            await next();
        }
    }
}
