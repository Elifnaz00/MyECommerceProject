using Castle.Core.Logging;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Bussines.Exceptions
{
    internal sealed class UnauthorizedExceptionHandler(ILogger<UnauthorizedExceptionHandler> logger) : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            if (exception is not UnauthorizedException unauthorizedAccessException)
            {
                return false;
            }

            logger.LogError(
               unauthorizedAccessException,
               "Exception occurred: {Message}",
               unauthorizedAccessException.Message);

            var model = new ProblemDetails
            {
                Status = StatusCodes.Status401Unauthorized,
                Type = exception.GetType().Name,
                Title = "Yetkilendirme Hatası!",
                Detail = exception.Message,
                Instance = $"{httpContext.Request.Method} {httpContext.Request.Path}"
            };

            httpContext.Response.StatusCode = model.Status.Value;

            await httpContext.Response
                .WriteAsJsonAsync(model, cancellationToken);

            return true;
        }
           
        }
    
}
