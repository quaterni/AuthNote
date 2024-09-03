using AuthNote.Domain.Authentication;
using AuthNote.LocalIdentity.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthNote.Infrastructure.Authentication.LocalIdentity
{
    internal class LocalIdentityTokenAccessor : ITokenAccessor
    {
        private readonly UserService _registrationService;

        public LocalIdentityTokenAccessor(UserService registrationService)
        {
            _registrationService = registrationService;
        }

        public async Task<string> GetToken(UserCredentials userCredentials)
        {
            return await _registrationService.LoginUser(userCredentials.Email, userCredentials.Password);
        }
    }
}
