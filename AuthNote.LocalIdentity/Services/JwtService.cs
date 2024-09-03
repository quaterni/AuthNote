using AuthNote.LocalIdentity;
using AuthNote.LocalIdentity.Options;
using AuthNote.LocalIdentity.Services.Abstractions;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AuthNote.LocalIdentity.Services
{
    public class JwtService : IJwtService
    {
        private JwtOptions _jwtOptions;

        public JwtService(IOptions<JwtOptions> options)
        {
            _jwtOptions = options.Value;
        }

        public string GetToken(Identity identity)
        {
            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.SecretKey)), 
                SecurityAlgorithms.HmacSha256);

            var idClaim = new Claim("identityId", identity.Id.ToString());

            var token = new JwtSecurityToken(
                claims: [ idClaim ],
                signingCredentials: signingCredentials,
                expires: DateTime.UtcNow.AddHours(_jwtOptions.ExpiredHours));

            var tokenValue = new JwtSecurityTokenHandler().WriteToken(token); 
            return tokenValue;
        }
    }
}
