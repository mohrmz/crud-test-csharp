namespace Mc2.CrudTest.AcceptanceTests.Tools.Core;

public interface IStartableHost : IHost
{
    void Start();
    void Stop();
}
