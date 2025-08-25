using Bank.Application.Exceptions;
using Bank.Application.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace Bank.WebAPI.Filter
{
    public class ExceptionFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception != null)
            {
                context.Result = new ObjectResult(string.Empty)
                {
                    StatusCode = (int?)GetCodeFromException(context.Exception),
                    Value = new ResponseResult
                    {
                        Message = context.Exception.Message,
                        Success = false,
                    }
                };
                context.ExceptionHandled = true;
            }
        }

        private HttpStatusCode GetCodeFromException(Exception exception)
        {
            switch (exception)
            {
                case BadRequestException:
                case ValidationModelException:
                    return HttpStatusCode.BadRequest;
                case NotFoundException:
                    return HttpStatusCode.NotFound;
                default:
                    return HttpStatusCode.InternalServerError;
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {

        }
    }
}