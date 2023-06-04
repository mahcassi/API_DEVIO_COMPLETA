
using API_DEVIO_COMPLETA.Data;
using API_DEVIO_COMPLETA.Extensions;
using DevIO.Api.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace API_DEVIO_COMPLETA.Configuration
{
    public static class IdentityConfig
    {
        public static IServiceCollection AddIdentityConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddDefaultIdentity<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddErrorDescriber<IdentityMensagensPortugues>()
                .AddDefaultTokenProviders();

            //JWT
            var appSettingsSection = configuration.GetSection("AppSettings");
            services.Configure<AppSettings> (appSettingsSection);

            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret); // pegando o secret e fazer o encoding do secret


            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = true;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters 
                { 
                    ValidateIssuerSigningKey = true, // valida se quem esta emitindo é o mesmo que vc recebeu no token
                    IssuerSigningKey = new SymmetricSecurityKey(key), // configurando a chave
                    ValidateIssuer = true, // valida o issuer conforme o nome do emissor
                    ValidateAudience = true, // valida onde o token é valido
                    ValidAudience = appSettings.ValidoEm, // apontando que é o audience
                    ValidIssuer = appSettings.Emissor // apontando quem é o emissor
                };

            });

            return services;
        }
    }
}
