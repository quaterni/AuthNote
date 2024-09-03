using AuthNote.Domain.Authentication;
using AuthNote.LocalIdentity.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthNote.Infrastructure.Authentication.LocalIdentity
{
    internal class LocalIdentityUserRegistrator : IUserRegistrator
    {
        private readonly UserService _registrationService;

        public LocalIdentityUserRegistrator(UserService registrationService)
        {
            _registrationService = registrationService;
        }

        public async Task<string> Register(UserCredentials userCredentials)
        {
            var identity = await _registrationService.RegisterUser(userCredentials.Username, userCredentials.Email, userCredentials.Password);

            return identity.Id.ToString();
        }
    }
}
