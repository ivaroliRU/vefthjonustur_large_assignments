using System;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace TechnicalRadiation.WebApi.Attributes
{
    public class AuthorizationAttribute : ActionFilterAttribute
    {
        string authString = "TechnicalRadiation";

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string authorizationToken = context.HttpContext.Request.Headers["Authorization"];

            if(authorizationToken == authString){
                Console.WriteLine("You are in :)");
            }
            else{
                Console.WriteLine("Not authorized >:(");
                context.Result = new UnauthorizedResult();
            }

            Console.WriteLine(context.HttpContext.Request.Path);
        }
    }
}