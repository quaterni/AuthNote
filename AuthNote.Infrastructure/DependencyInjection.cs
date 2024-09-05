using AuthNote.Domain.Authentication;
using AuthNote.Domain.Data.Abstractions;
using AuthNote.Infrastructure.Authentication.LocalIdentity;
using AuthNote.Infrastructure.Authentication.LocalIdentity.Configurations;
using AuthNote.Infrastructure.Authorization;
using AuthNote.Infrastructure.Data;
using AuthNote.Infrastructure.Data.Repositories;
using AuthNote.LocalIdentity.Data;
using AuthNote.LocalIdentity.Options;
using AuthNote.LocalIdentity.Services;
using AuthNote.LocalIdentity.Services.Abstractions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AuthNote.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(
                options => options
                    .UseNpgsql(configuration.GetConnectionString("ApplicationDatabase"))
                    .UseSnakeCaseNamingConvention());

            services.AddScoped<IUserRepository, UserRepository>();

            AddLocalIdentity(services, configuration);

            AddAuthorization(services);

            return services;
        }

        public static void AddLocalIdentity(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JwtOptions>(options => configuration.GetSection("LocalIdentityJwt").Bind(options));

            services.AddDbContext<IdentityDbContext>(
                options => options
                    .UseNpgsql(configuration.GetConnectionString("IdentityDatabase"))
                    .UseSnakeCaseNamingConvention());

            services.AddTransient<IHashService, HashService>();
            services.AddTransient<IJwtService, JwtService>();

            services.AddScoped<UserService>();

            services.AddScoped<IUserRegistrator, LocalIdentityUserRegistrator>();
            services.AddScoped<ITokenAccessor, LocalIdentityTokenAccessor>();

            services.ConfigureOptions<JwtBearerOptionsConfigurations>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer();

            services.AddAuthorization();

        }

        public static void AddAuthorization(IServiceCollection services)
        {
            services.AddScoped<AuthorizationService>();

            services.AddTransient<IClaimsTransformation, RoleClaimsTransformation>();
        }
    }
}
