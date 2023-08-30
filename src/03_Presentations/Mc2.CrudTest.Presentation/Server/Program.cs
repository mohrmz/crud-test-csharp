using Mc2.CrudTest.Presentation.Server.Extentions;
using Mc2.CrudTest.Presentation.Server.Extentions.Migrations;
using Mc2.CrudTest.Presentation.Server.Extentions.Serilog.Extentions;

namespace Mc2.CrudTest.Presentation.Server;

public class Program
{
    public static void Main(string[] args)
    {
        SerilogExtensions.RunWithSerilogExceptionHandling(() =>
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.AddSerilog(o =>
            {
                o.ApplicationName = builder.Configuration.GetValue<string>("ApplicationName");
                o.ServiceId = builder.Configuration.GetValue<string>("ServiceId");
                o.ServiceName = builder.Configuration.GetValue<string>("ServiceName");
                o.ServiceVersion = builder.Configuration.GetValue<string>("ServiceVersion");
            }).ConfigureServices().MigrateDatabase().ConfigurePipeline();
            app.Run();
        });
    }
}

