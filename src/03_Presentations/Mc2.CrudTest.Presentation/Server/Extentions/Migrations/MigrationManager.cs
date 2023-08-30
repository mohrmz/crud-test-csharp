using Mc2.CrudTest.Infrastructure.Data.SqlServer.Commands.Common;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Presentation.Server.Extentions.Migrations;

public static class MigrationManager
{
    public static WebApplication MigrateDatabase(this WebApplication webApp)
    {
        using (var scope = webApp.Services.CreateScope())
        {
            using (var appContext = scope.ServiceProvider.GetRequiredService<CustomerCommandDbContext>())
            {
                try
                {
                    appContext.Database.EnsureCreated();
                }
                catch (Exception ex)
                {
                    
                    throw;
                }
            }
        }
        return webApp;
    }
}
