using E_Commerce.Service.Errors;
using System.Text.Json;

namespace E_Commerce.Api.MiddleWares
{
    public class ExceptionMiddleWare
    {
        readonly RequestDelegate _next;
        readonly ILogger<ExceptionMiddleWare> _logger;
        readonly IHostEnvironment _environment;
        public ExceptionMiddleWare(RequestDelegate next,ILogger<ExceptionMiddleWare> logger,IHostEnvironment env)
        {
            _next = next;
            _logger = logger;
            _environment = env;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                int statusCode = StatusCodes.Status500InternalServerError;
                _logger.LogError(ex,ex.Message);
                httpContext.Response.ContentType = "application/json";
                httpContext.Response.StatusCode = statusCode;
                var response = _environment.IsDevelopment()
                    ? new ApiException(statusCode, ex.Message, ex.StackTrace.ToString())
                    : new ApiException(statusCode);

                var option = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

                var json = JsonSerializer.Serialize(response,option);
                await httpContext.Response.WriteAsync(json);
            }
        }

    }
}
