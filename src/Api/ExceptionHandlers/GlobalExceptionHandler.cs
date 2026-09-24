using Application.Exceptions;
using Microsoft.AspNetCore.Diagnostics;

namespace Api.ExceptionHandlers;

public class GlobalExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        if (exception is EmailAlreadyExistsException)
        {
            httpContext.Response.StatusCode =
                StatusCodes.Status409Conflict;

            await httpContext.Response.WriteAsJsonAsync(
                new
                {
                    message = exception.Message
                },
                cancellationToken
            );

            return true;
        }

        return false;
    }
}