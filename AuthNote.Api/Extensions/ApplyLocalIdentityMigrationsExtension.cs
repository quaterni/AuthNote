using AuthNote.Infrastructure.Data;
using AuthNote.LocalIdentity.Data;
using Microsoft.EntityFrameworkCore;

namespace AuthNote.Api.Extensions
{
    public static class ApplyLocalIdentityMigrationsExtension
    {
        public static void ApplyLocalIdentityMigrations(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();

            using var dbContext = scope.ServiceProvider.GetRequiredService<IdentityDbContext>();

            dbContext.Database.Migrate();
        }
    }
}
