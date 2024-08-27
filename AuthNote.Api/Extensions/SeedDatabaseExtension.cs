using AuthNote.Domain.Models;
using AuthNote.Infrastructure.Data;

namespace AuthNote.Api.Extensions
{
    public static class SeedDatabaseExtension
    {
        public static void SeedDatabase(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();

            using var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            Console.WriteLine("-- Trying to seed database");

            if (context.Set<User>().Any())
            {
                Console.WriteLine("-- Database has users, stop seeding");
                return;
            }

            Console.WriteLine("-- Database has not users, continue seeding");

            var user = User.Create("sofick", "sofick@mail.com");

            user.AddNote("Note 1", "");
            user.AddNote("Note 2", "Content");
            user.AddNote("Note 3", "Some content");

            context.Add(user);

            context.SaveChanges();

            Console.WriteLine("-- Seeding has done");
        }
    }
}
