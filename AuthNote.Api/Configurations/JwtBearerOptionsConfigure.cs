using AuthNote.Api.Configurations.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;

namespace AuthNote.Api.Configurations
{
    public class JwtBearerOptionsConfigure : IConfigureNamedOptions<JwtBearerOptions>
    {
        private readonly JwtAuthenticationOptions _jwtAuthenticationOptions;

        public JwtBearerOptionsConfigure(IOptions<JwtAuthenticationOptions> options)
        {
            _jwtAuthenticationOptions = options.Value;
        }

        public void Configure(string? name, JwtBearerOptions options)
        {
            Configure(options);
        }

        public void Configure(JwtBearerOptions options)
        {
            options.TokenValidationParameters.ValidateIssuer = true;
            options.TokenValidationParameters.ValidateAudience= true;
            options.TokenValidationParameters.ValidIssuer = _jwtAuthenticationOptions.Issuer;
            options.TokenValidationParameters.ValidAudience = _jwtAuthenticationOptions.Audience;
            options.MetadataAddress = _jwtAuthenticationOptions.MetadataAddress;
            options.RequireHttpsMetadata = _jwtAuthenticationOptions.RequireHttpsMetadata;
        }
    }
}
