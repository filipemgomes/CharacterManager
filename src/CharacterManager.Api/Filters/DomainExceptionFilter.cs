using CharacterManager.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CharacterManager.Api.Filters
{
    public class DomainExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is DomainException domainException)
            {
                context.Result = new BadRequestObjectResult(new
                {
                    Errors = new[] { domainException.Message }
                });
                context.ExceptionHandled = true;
            }
        }
    }

}