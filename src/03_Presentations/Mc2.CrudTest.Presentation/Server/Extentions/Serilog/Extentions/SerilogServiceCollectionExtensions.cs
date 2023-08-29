using Mc2.CrudTest.Presentation.Server.Extentions.Serilog.Options;
using Serilog;
using Serilog.Enrichers.Span;
using Serilog.Exceptions;

namespace Mc2.CrudTest.Presentation.Server.Extentions.Serilog.Extentions;

public static class SerilogServiceCollectionExtensions
{
    public static WebApplicationBuilder AddSerilog(this WebApplicationBuilder builder, IConfiguration configuration)
    {
        builder.Services.Configure<SerilogApplicationEnricherOptions>(configuration);
        return AddServices(builder);
    }

    public static WebApplicationBuilder AddSerilog(this WebApplicationBuilder builder, IConfiguration configuration, string sectionName)
    {
        return builder.AddSerilog(configuration.GetSection(sectionName));
    }

    public static WebApplicationBuilder AddSerilog(this WebApplicationBuilder builder, Action<SerilogApplicationEnricherOptions> setupAction)
    {
        builder.Services.Configure(setupAction);
        return AddServices(builder);
    }

    private static WebApplicationBuilder AddServices(WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<ApplicaitonEnricherOption>();
        builder.Host.UseSerilog(delegate (HostBuilderContext ctx, IServiceProvider services, LoggerConfiguration lc)
        {
            lc.Enrich.FromLogContext().Enrich.With(services.GetRequiredService<ApplicaitonEnricherOption>()).Enrich.WithExceptionDetails().Enrich.WithSpan().ReadFrom.Configuration(ctx.Configuration);
        });
        return builder;
    }
}
