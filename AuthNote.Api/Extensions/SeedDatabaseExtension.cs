using AuthNote.Domain.Models;
using AuthNote.Infrastructure.Data;
using AuthNote.LocalIdentity.Services;
using AuthNote.LocalIdentity.Services.Abstractions;

namespace AuthNote.Api.Extensions
{
    public static class SeedDatabaseExtension
    {
        public static void SeedDatabase(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();

            using var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            Console.WriteLine("-- Seed: trying to seed database");

            if (context.Set<User>().Any())
            {
                Console.WriteLine("-- Seed: database has users, stop seeding");
                return;
            }

            Console.WriteLine("-- Seed: database has not users");
            Console.WriteLine("-- Seed: creating identity");

            var name = "sofick";
            var email = "sofick@mail.com";
            var password = "123";
            var registrationService = scope.ServiceProvider.GetRequiredService<UserService>();
            var identityId = registrationService.RegisterUser(name, email, password).Result;

            Console.WriteLine("-- Seed: identity has created");

            var user = User.Create(name, email, identityId.Id.ToString());

            user.AddNote("Note 1", "");
            user.AddNote("Note 2", "Content");
            user.AddNote("Note 3", "Some content");

            context.Add(user);

            context.SaveChanges();

            Console.WriteLine("-- Seed: seeding has done");
        }
    }
}
