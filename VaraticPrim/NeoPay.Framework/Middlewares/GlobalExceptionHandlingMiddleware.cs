using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using NeoPay.Framework.Errors;
using NeoPay.Framework.Errors.ApiError;

namespace NeoPay.Framework.Middlewares;

public class GlobalExceptionHandlingMiddleware
{
    private readonly ILogger<GlobalExceptionHandlingMiddleware> _logger;
    private readonly RequestDelegate                            _next;

    public GlobalExceptionHandlingMiddleware(RequestDelegate next, ILogger<GlobalExceptionHandlingMiddleware> logger)
    {
        _next   = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, "Internal server error: {Message}", exception.Message);

            var error = ApiErrorBuilder.New()
                                       .SetCode(ApiErrorCodes.InternalServerError)
                                       .SetMessage("Unexpected error occured. Please contact your Administrator.")
                                       .Build();

            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

            await httpContext.Response.WriteAsJsonAsync(error);
        }
    }
}