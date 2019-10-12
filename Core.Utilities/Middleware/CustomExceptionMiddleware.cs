using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Core.Utilities.Middleware
{
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var response = context.Response;
            var customException = exception as BaseCustomException;
            var statusCode = (int)HttpStatusCode.InternalServerError;
            var message = exception.Message;
            
            if (null != customException)
            {
                message = customException.Message;
                statusCode = customException.StatusCode;
            }

            response.ContentType = "application/json";
            response.StatusCode = statusCode;
            await response.WriteAsync(JsonConvert.SerializeObject(new CustomErrorResponse
            {
                StatusCode =  statusCode,
                Message = message,
                
            }));
        }
    }

    public class BaseCustomException : Exception
    {
        public int StatusCode { get; }
        public string Description { get; }

        public BaseCustomException(string message, int statusCode = 400) : base(message)
        {
            StatusCode = statusCode;
        }
    }

    public class CustomErrorResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
    }

    public class NotFoundCustomException : BaseCustomException
    {
        public NotFoundCustomException(string message, string description) : base(message, (int)HttpStatusCode.NotFound)
        {
        }
    }

}
