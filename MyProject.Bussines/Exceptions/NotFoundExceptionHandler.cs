using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Castle.Core.Logging;
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

            if (exception is not NotFoundException notFoundException)
            {
                return false;
            }

            logger.LogError(notFoundException,
                            "İstisna Oluştu: {Message}",
                            notFoundException.Message
                            );

            var model = new ProblemDetails
            {
                Status = StatusCodes.Status404NotFound,
                Type = notFoundException.GetType().Name,
                Title = "Not Found",
                Detail = notFoundException.Message,
                Instance = $"{httpContext.Request.Method} {httpContext.Request.Path}"
            };

            httpContext.Response.StatusCode = model.Status.Value;

            await httpContext.Response
                .WriteAsJsonAsync(model, cancellationToken);

            return true;
        }

    }
}
