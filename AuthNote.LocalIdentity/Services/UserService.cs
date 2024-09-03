using AuthNote.LocalIdentity.Data;
using AuthNote.LocalIdentity.Services.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace AuthNote.LocalIdentity.Services
{
    public class UserService
    {
        private readonly IHashService _hashService;
        private readonly IJwtService _jwtService;
        private readonly IdentityDbContext _identityDbContext;

        public UserService(
            IHashService hashService,
            IJwtService jwtService,
            IdentityDbContext identityDbContext)
        {
            _hashService = hashService;
            _jwtService = jwtService;
            _identityDbContext = identityDbContext;
        }

        public async Task<Identity> RegisterUser(string userName, string email, string password)
        {
            var hashPassword = _hashService.HashPassword(password);

            var identity = new Identity()
            {
                Username = userName,
                Email = email,
                PasswordHash = hashPassword,
                Id = Guid.NewGuid()
            };

            _identityDbContext.Set<Identity>().Add(identity);

            await _identityDbContext.SaveChangesAsync();

            return identity;
        }

        public async Task<string> LoginUser(string email, string password)
        {
            var identity = await _identityDbContext
                .Set<Identity>()
                .FirstOrDefaultAsync(identity => identity.Email.Equals(email));

            if (identity == null)
            {
                throw new ApplicationException("Identity not found");
            }

            if (!_hashService.VerifyPassword(password, identity))
            {
                throw new ApplicationException("Identity password not correct");
            }

            return _jwtService.GetToken(identity);
        }
    }
}
