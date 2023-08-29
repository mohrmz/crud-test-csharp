using Framework.Core.ApplicationServices.Commands;
using Framework.Core.ApplicationServices.Events;
using Framework.Core.ApplicationServices.Queries;
using Framework.Endpoints.AutoMapper.Extentions;
using Framework.Endpoints.Extentions.DependencyInjection;
using Framework.Endpoints.Extentions.ModelBinding;
using Framework.Infrastructures.Data.Commands.Interceptors;
using Mc2.CrudTest.Infrastructure.Data.SqlServer.Commands.Common;
using Mc2.CrudTest.Infrastructure.Data.SqlServer.Queries.Common;
using Mc2.CrudTest.Presentation.Server.Decorators;
using Mc2.CrudTest.Presentation.Server.Extentions.Swaggers;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Mc2.CrudTest.Presentation.Server.Extentions;

public static class HostingExtensions
{
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {
        IConfiguration configuration = builder.Configuration;

        builder.Services.AddSingleton<CommandDispatcherDecorator, CommandDecorator>();
        builder.Services.AddSingleton<QueryDispatcherDecorator, QueryDecorator>();
        builder.Services.AddSingleton<EventDispatcherDecorator, EventDecorator>();

        builder.Services.AddApiCore("Mc2");

        //microsoft
        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddNonValidatingValidator();

        builder.Services.AddAutoMapperProfiles(configuration, "AutoMapper");

        //CommandDbContext
        builder.Services.AddDbContext<CustomerCommandDbContext>(
            c => c.UseSqlServer(configuration.GetConnectionString("CommandDb_ConnectionString"))
                  .AddInterceptors(new AddAuditDataInterceptor()));

        //QueryDbContext
        builder.Services.AddDbContext<CustomerQueryDbContext>(
            c => c.UseSqlServer(configuration.GetConnectionString("QueryDb_ConnectionString")));

        builder.Services.AddSwagger(configuration, "Swagger");

        return builder.Build();
    }

    public static WebApplication ConfigurePipeline(this WebApplication app)
    {

        app.UseApiExceptionHandler();

        //Serilog
        app.UseSerilogRequestLogging();

        app.UseSwaggerUI("Swagger");

        app.UseStatusCodePages();

        app.UseCors(delegate (CorsPolicyBuilder builder)
        {
            builder.AllowAnyOrigin();
            builder.AllowAnyHeader();
            builder.AllowAnyMethod();
        });

        app.UseHttpsRedirection();

        var controllerBuilder = app.MapControllers();

        return app;
    }
}
