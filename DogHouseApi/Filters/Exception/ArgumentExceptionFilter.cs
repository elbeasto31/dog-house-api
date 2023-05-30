using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DogHouseApi.Filters.Exception
{
    public class ArgumentExceptionFilter  : Attribute, IExceptionFilter 
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is not ArgumentException exception || context.ExceptionHandled)
                return;

            context.Result = new BadRequestObjectResult(exception.Message);
            context.ExceptionHandled = true;
        }
    }
}