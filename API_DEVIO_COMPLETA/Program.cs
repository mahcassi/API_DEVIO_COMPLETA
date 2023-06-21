
using API_DEVIO_COMPLETA.Configuration;
using API_DEVIO_COMPLETA.Extensions;
using Data.Data.Context;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using WEBAPI.Configuration;

namespace WEBAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddDbContext<MeuDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddIdentityConfiguration(builder.Configuration);

            builder.Services.AddAutoMapper(typeof(Program));

            builder.Services
                .AddHealthChecks().AddSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), name: "BancoSQL");

            builder.Services.AddHealthChecksUI().AddSqlServerStorage(builder.Configuration.GetConnectionString("DefaultConnection")); ;

            builder.Services.ResolveDependencies();

            builder.Services.WebApiConfig();

            builder.Services.AddSwaggerConfig();

            builder.Services.AddSession();

            builder.Services.AddLoggingConfiguration();

            var app = builder.Build();
            var apiVersionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseCors("Development");
            }
            else
            {
                app.UseCors("Production");
                app.UseHsts();
            }

            app.UseSwaggerConfig(apiVersionDescriptionProvider);

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseMiddleware<ExceptionMiddleware>();

            app.UseMvcConfiguration();

            app.UseLoggingConfiguration();

            app.UseHealthChecks("/api/hc", new HealthCheckOptions
            {
                Predicate = p => true,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });

            app.UseHealthChecksUI(options => { 
                options.UIPath = "/api/hc-ui";
                options.ResourcesPath = $"{options.UIPath}/resources";
                options.UseRelativeApiPath = false;
                options.UseRelativeResourcesPath = false;
                options.UseRelativeWebhookPath = false;
            });

            app.UseSession();

            app.MapControllers();

            app.Run();
        }
    }
}