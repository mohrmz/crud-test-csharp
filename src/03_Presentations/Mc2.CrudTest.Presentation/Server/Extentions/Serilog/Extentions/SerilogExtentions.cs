using Serilog;

namespace Mc2.CrudTest.Presentation.Server.Extentions.Serilog.Extentions;

public class SerilogExtensions
{
    public static void RunWithSerilogExceptionHandling(Action action, string startUpMessage = "Starting up", string exceptionMessage = "Unhandled exception", string shutdownMessage = "Shutdown complete")
    {
        Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateBootstrapLogger();
        Log.Information(startUpMessage);
        try
        {
            action();
        }
        catch (Exception exception)
        {
            Log.Fatal(exception, exceptionMessage);
        }
        finally
        {
            Log.Information(shutdownMessage);
            Log.CloseAndFlush();
        }
    }
}
