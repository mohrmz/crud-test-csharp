using FluentValidation.AspNetCore;
using Framework.Endpoints.Middlewares.ApiExceptionHandler;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Data.SqlClient;

namespace Framework.Endpoints.Extentions.DependencyInjection;


public static class AddApiConfigurationExtensions
{
    public static IServiceCollection AddApiCore(this IServiceCollection services, params string[] assemblyNamesForLoad)
    {
        services.AddControllers().AddFluentValidation();
        services.AddDependencies(assemblyNamesForLoad);

        return services;
    }

    public static void UseApiExceptionHandler(this IApplicationBuilder app)
    {
        app.UseApiExceptionsHandler(options =>
        {
            options.AddResponseDetails = (context, ex, error) =>
            {
                if (ex.GetType().Name == typeof(SqlException).Name)
                {
                    error.Detail = "Exception was a database exception!";
                }
            };
            options.DetermineLogLevel = ex =>
            {
                if (ex.Message.StartsWith("cannot open database", StringComparison.InvariantCultureIgnoreCase) ||
                    ex.Message.StartsWith("a network-related", StringComparison.InvariantCultureIgnoreCase))
                {
                    return LogLevel.Critical;
                }
                return LogLevel.Error;
            };
        });

    }
}
