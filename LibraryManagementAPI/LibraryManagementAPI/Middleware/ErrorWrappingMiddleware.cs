using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;


namespace LibraryManagementAPI.Middleware
{
    public class ErrorWrappingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorWrappingMiddleware> _logger;
        

        public ErrorWrappingMiddleware(RequestDelegate next)
        {
            if (next == null)
            {
                throw new ArgumentNullException(nameof(next)
                    , nameof(next) + " is required");
            }
            _next = next;
        }

        public ErrorWrappingMiddleware(RequestDelegate next, ILogger<ErrorWrappingMiddleware> logger)
        {
            _next = next;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
      

        private static void writeErrorResponse(HttpContext Context, params string[] Errors)
        {
            Context.Response.ContentType = "application/json";
            var writer = new Utf8JsonWriter(Context.Response.BodyWriter);
            {
                writer.WriteStartObject();
                writer.WriteBoolean("isValid", false);
                writer.WriteStartArray("errors");

                foreach (var error in Errors)
                {
                    writer.WriteStringValue(error);
                }

                writer.WriteEndArray();
                writer.WriteEndObject();
                writer.Flush();
            }
            //Context.Response.ContentType = "application/json";
        }

       

       

        public async Task InvokeAsync(HttpContext Context)
        {
           
            if (Context == null)
            {
                throw new ArgumentNullException(nameof(Context)
                    , nameof(Context) + " is required");
            }
            //try
            //{
            //    await _next.Invoke(Context);
            //}
            //catch (Exception ex)
            //{
            //    _logger.LogError(ex, ex.Message);
            //    Context.Response.StatusCode = 500;
            //}

            //await _next(Context);
            try
            {
                await _next(Context);
            }
            //catch (HttpStatusCodeException ex)
            //{
            //    await HandleExceptionAsync(context, ex);
            //}
            catch (Exception exceptionObj)
            {
                var e = exceptionObj;
            }

            if (Context.Response.StatusCode == 401)
            {
                writeErrorResponse(Context, "Please log in");
            }
            else if (Context.Response.StatusCode == 400)
            {
                writeErrorResponse(Context, "Please log in");
            }
            else if (Context.Response.StatusCode == 500)
            {
                writeErrorResponse(Context, "Custom Internal Server Error");
            }
        }
    }
}
