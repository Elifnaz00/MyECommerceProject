using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MyProject.Bussines.Exceptions
{
    internal sealed class NotFoundExceptionHandler(ILogger<NotFoundExceptionHandler> logger) : IExceptionHandler
    {

        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {

            if (exception is not NotFoundException)
            {
                return false;
            }

            logger.LogError(exception, "An unexpected error occurred");

            var model = new ProblemDetails
            {
                Status = (int)HttpStatusCode.NotFound,
                Type = exception.GetType().Name,
                Title = "An unexpected error occurred",
                Detail = exception.Message,
                Instance = $"{httpContext.Request.Method} {httpContext.Request.Path}"
            };

            httpContext.Response.StatusCode = (int)model.Status;

            await httpContext.Response
                .WriteAsJsonAsync(model, cancellationToken);

            return true;
        }

    }
}
