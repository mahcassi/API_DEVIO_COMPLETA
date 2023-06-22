using API_DEVIO_COMPLETA.Extensions;
using Elmah.Io.Extensions.Logging;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

namespace API_DEVIO_COMPLETA.Configuration
{
    public static class LoggerConfig
    {
        public static IServiceCollection AddLoggingConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddElmahIo(o =>
            {
                o.ApiKey = "8e77404a9f274c65837455cdaf7375ea";
                o.LogId = new Guid("1025976f-41ff-4143-8576-1d9393bf43c2");
            });

            // Adicionando logs do asp.net core no elmah
            //services.AddLogging(builder => {
            //    services.AddElmahIo(o =>
            //    {
            //        o.ApiKey = "8e77404a9f274c65837455cdaf7375ea";
            //        o.LogId = new Guid("1025976f-41ff-4143-8576-1d9393bf43c2");
            //    });
            //    builder.AddFilter<ElmahIoLoggerProvider>(null, LogLevel.Warning);
            //});

            services
               .AddHealthChecks()
               .AddElmahIoPublisher(options =>
               {
                   options.ApiKey = "8e77404a9f274c65837455cdaf7375ea";
                   options.LogId = new Guid("1025976f-41ff-4143-8576-1d9393bf43c2");
                   options.HeartbeatId = "API Fornecedores";
               })
               .AddCheck("Produtos", new SqlServerHealthCheck(configuration.GetConnectionString("DefaultConnection")))
               .AddSqlServer(configuration.GetConnectionString("DefaultConnection"), name: "BancoSQL");

            services.AddHealthChecksUI().AddInMemoryStorage();

            return services;
        }


        public static IApplicationBuilder UseLoggingConfiguration(this IApplicationBuilder app)
        {
            app.UseElmahIo();

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

            return app;
        }
    }
}
