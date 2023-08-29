using Microsoft.AspNetCore.Builder;

namespace Framework.Endpoints.Middlewares.ApiExceptionHandler;

public static class ApiExceptionMiddlewareExtensions
{
    public static IApplicationBuilder UseApiExceptionsHandler(this IApplicationBuilder builder)
    {
        var options = new ApiExceptionOptions();
        return builder.UseMiddleware<ApiExceptionMiddleware>(options);
    }

    public static IApplicationBuilder UseApiExceptionsHandler(this IApplicationBuilder builder,
        Action<ApiExceptionOptions> configureOptions)
    {
        var options = new ApiExceptionOptions();
        configureOptions(options);

        return builder.UseMiddleware<ApiExceptionMiddleware>(options);
    }
}