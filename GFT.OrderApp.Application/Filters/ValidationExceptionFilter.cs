using GFT.OrderApp.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System.Net;

namespace GFT.OrderApp.Application.Filters
{
    public class ValidationExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is GFTValidationException)
            {
                var exception = (GFTValidationException)context.Exception;

                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.HttpContext.Response.ContentType = "application/json";

                var contentResult = new ContentResult();
                contentResult.Content = JsonConvert.SerializeObject(exception.ValidationErrors);

                context.Result = contentResult;

                context.Exception = null;
            }

        }
    }
}
