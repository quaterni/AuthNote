using AuthNote.Domain.Models;
using AuthNote.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthNote.Infrastructure.Authorization
{
    internal sealed class AuthorizationService
    {
        private readonly ApplicationDbContext _dbContext;

        public AuthorizationService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UserRolesResponse> GetRolesForUserAsync(string identityId)
        {
            var roles = await _dbContext.Set<User>()
                .Where(user => user.IdentityId == identityId)
                .Select(user => new UserRolesResponse
                {
                    UserId = user.Id,
                    Roles = user.Roles.ToList()
                })
                .FirstAsync();

            return roles;
        }
    }

    public class UserRolesResponse
    {
        public Guid UserId { get; init; }
        public List<Role> Roles { get; init; }
    }
}
