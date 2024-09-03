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

        public async Task Add(User user)
        {
            _context.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User?> GetUserByIdentityId(string identityId)
        {
            return await _context
                .Set<User>()
                .Include(user=> user.Notes)
                .FirstOrDefaultAsync(user=> user.IdentityId.Equals(identityId));
        }

        public async Task<ICollection<User>> GetUsers()
        {
            return await _context.Set<User>().ToListAsync();
        }
    }
}
