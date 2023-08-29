using Microsoft.Extensions.Options;
using Serilog.Core;
using Serilog.Events;
using System.Reflection;

namespace Mc2.CrudTest.Presentation.Server.Extentions.Serilog.Options;

public class ApplicaitonEnricherOption : ILogEventEnricher
{
    private readonly SerilogApplicationEnricherOptions _options;
    public ApplicaitonEnricherOption(IOptions<SerilogApplicationEnricherOptions> options)
    {
        _options = options.Value;
    }

    public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
    {
        LogEventProperty property  = propertyFactory.CreateProperty("ApplicationName", _options.ApplicationName);
        LogEventProperty property2 = propertyFactory.CreateProperty("ServiceName", _options.ServiceName);
        LogEventProperty property3 = propertyFactory.CreateProperty("ServiceVersion", _options.ServiceVersion);
        LogEventProperty property4 = propertyFactory.CreateProperty("ServiceId", _options.ServiceId);
        LogEventProperty property5 = propertyFactory.CreateProperty("MachineName", Environment.MachineName);
        LogEventProperty property6 = propertyFactory.CreateProperty("EntryPoint", Assembly.GetEntryAssembly()!.GetName().Name);
        logEvent.AddPropertyIfAbsent(property);
        logEvent.AddPropertyIfAbsent(property2);
        logEvent.AddPropertyIfAbsent(property3);
        logEvent.AddPropertyIfAbsent(property5);
        logEvent.AddPropertyIfAbsent(property6);
        logEvent.AddPropertyIfAbsent(property4);
    }
}
