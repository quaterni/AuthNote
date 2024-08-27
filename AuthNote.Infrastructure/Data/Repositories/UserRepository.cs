using AuthNote.Domain.Data.Abstractions;
using AuthNote.Domain.Models;
using Microsoft.EntityFrameworkCore;


namespace AuthNote.Infrastructure.Data.Repositories
{
    internal class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<User>> GetUsers()
        {
            return await _context.Set<User>().ToListAsync();
        }
    }
}
