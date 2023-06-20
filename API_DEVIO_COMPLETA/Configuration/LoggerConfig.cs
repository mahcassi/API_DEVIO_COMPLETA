using Elmah.Io.Extensions.Logging;

namespace API_DEVIO_COMPLETA.Configuration
{
    public static class LoggerConfig
    {
        public static IServiceCollection AddLoggingConfiguration(this IServiceCollection services)
        {
            services.AddElmahIo(o =>
            {
                o.ApiKey = "8e77404a9f274c65837455cdaf7375ea";
                o.LogId = new Guid("1025976f-41ff-4143-8576-1d9393bf43c2");
            });

            // Adicionando logs do asp.net core no elmah
            services.AddLogging(builder => {
                services.AddElmahIo(o =>
                {
                    o.ApiKey = "8e77404a9f274c65837455cdaf7375ea";
                    o.LogId = new Guid("1025976f-41ff-4143-8576-1d9393bf43c2");
                });
                builder.AddFilter<ElmahIoLoggerProvider>(null, LogLevel.Warning);
            });

            return services;
        }


        public static IApplicationBuilder UseLoggingConfiguration(this IApplicationBuilder app)
        {
            app.UseElmahIo();

            return app;
        }
    }
}
