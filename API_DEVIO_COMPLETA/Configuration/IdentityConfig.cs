
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
                x.RequireHttpsMetadata = true; //- Define se a autenticação requer metadados HTTPS. Se definido como true, o servidor exigirá que as solicitações sejam feitas através de uma conexão segura (HTTPS).
                x.SaveToken = true; //- Indica se o token JWT recebido deve ser armazenado no contexto de autenticação. Isso pode ser útil para recuperar informações do token posteriormente.
                x.TokenValidationParameters = new TokenValidationParameters 
                { 
                    ValidateIssuerSigningKey = true, // verificar se a chave usada para assinar o token JWT é válida, significa que o sistema irá verificar se a chave usada para assinar o token é a mesma chave que estamos usando para verificar a assinatura.
                    IssuerSigningKey = new SymmetricSecurityKey(key), // configurando a chave
                    ValidateIssuer = true, //  Indica se o emissor (issuer) do token deve ser validado..
                    ValidateAudience = true, //  ndica se a audiência (audience) do token deve ser validada
                    ValidAudience = appSettings.ValidoEm, // apontando que é a audience válida do token.
                    ValidIssuer = appSettings.Emissor // apontando quem é o emissor válido do token.
                };

            });

            return services;
        }
    }
}
