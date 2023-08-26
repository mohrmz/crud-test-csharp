using Mc2.CrudTest.AcceptanceTests.Tools;
using Mc2.CrudTest.AcceptanceTests.Tools.NetCoreHosting;

namespace Mc2.CrudTest.AcceptanceTests.Hooks
{
    public sealed class RunHostHook
    {
        private static readonly DotNetCoreHost Host =
            new DotNetCoreHost(new DotNetCoreHostOptions
            {
                Port = HostConstants.Port,
                CsProjectPath = HostConstants.CsProjectPath
            });

        [BeforeFeature]
        public static void StartHost()
        {
            Host.Start();
        }

        [AfterFeature]
        public static void ShutdownHost()
        {
            Host.Stop();
        }
    }
}
