
using API_DEVIO_COMPLETA.Configuration;
using Data.Data.Context;
using Microsoft.EntityFrameworkCore;
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
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<MeuDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddIdentityConfiguration(builder.Configuration);

            builder.Services.AddAutoMapper(typeof(Program));

            builder.Services.ResolveDependencies();

            builder.Services.WebApiConfig();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseAuthentication();

            app.UseMvcConfiguration();

            app.MapControllers();

            app.Run();
        }
    }
}