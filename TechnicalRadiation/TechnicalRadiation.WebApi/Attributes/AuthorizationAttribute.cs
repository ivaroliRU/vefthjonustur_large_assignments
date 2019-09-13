using System;
using Microsoft.AspNetCore.Mvc.Filters;

namespace TechnicalRadiation.WebApi.Attributes
{
    public class AuthorizationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine(context.HttpContext.Connection.LocalIpAddress);
            Console.WriteLine(context.HttpContext.Request.Path);
        }
    }
}