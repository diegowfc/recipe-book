using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RecipeBook.Communication.Response;
using RecipeBook.Exceptions;
using RecipeBook.Exceptions.ExceptionBase;
using System.Net;

namespace RecipeBook.API.Filters;

public class ExceptionFilters : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is RecipeBookException )
        {
            HandleRecipeBookException(context);
        }
        else
        {

        }
    }

    private void HandleRecipeBookException(ExceptionContext context)
    {
        if (context.Exception is ValidationErrorsExceptions)
        {
            HandleValidationException(context);
        }

    }

    private void HandleValidationException(ExceptionContext context)
    {
        var validationErrorException = context.Exception as ValidationErrorsExceptions;

        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        context.Result = new ObjectResult(new ErrorResponseJSON(validationErrorException.Errors));
    }

    private void HandleUnknownError(ExceptionContext context)
    {
        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        context.Result = new ObjectResult(new ErrorResponseJSON(ExceptionInvalidMessages.UnknownError));
    }
}

