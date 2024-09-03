using AuthNote.LocalIdentity.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthNote.Infrastructure.Authentication.LocalIdentity.Configurations
{
    internal class JwtBearerOptionsConfigurations : IConfigureNamedOptions<JwtBearerOptions>
    {
        private JwtOptions _jwtOptions;

        public JwtBearerOptionsConfigurations(IOptions<JwtOptions> options)
        {
            _jwtOptions = options.Value;
        }

        public void Configure(string? name, JwtBearerOptions options)
        {
            Configure(options);
        }

        public void Configure(JwtBearerOptions options)
        {
            options.TokenValidationParameters = new()
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_jwtOptions.SecretKey))
            };
        }
    }
}
