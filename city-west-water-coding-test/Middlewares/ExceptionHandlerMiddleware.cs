using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace city_west_water_coding_test.Middlewares
{
    /// <summary>
    /// Middleware which to catch all the exception that is thrown from the application and log to a file
    /// </summary>
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public ExceptionHandlerMiddleware(
            RequestDelegate next,
            ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger("ExceptionLogger");
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                var id = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
                _logger.LogError($"id: {id} | error: {ex}");
                await HandleExceptionAsync(httpContext, ex, id);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception, long id)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            return context.Response.WriteAsync(new ErrorMessage()
            {
                StatusCode = context.Response.StatusCode,
                Message = $"Something went wrong, please contact system admin. Error code: {id}"
            }.ToString());
        }

        public class ErrorMessage
        {
            public int StatusCode { get; set; }
            public string Message { get; set; }
        }
    }
}