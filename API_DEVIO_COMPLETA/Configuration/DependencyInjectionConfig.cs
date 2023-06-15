using DevIO.Business.Intefaces;
using Data.Data.Context;
using Data.Data.Repository;
using DevIO.Business.Notificacoes;
using DevIO.Business.Services;
using API_DEVIO_COMPLETA.Extensions;
using Microsoft.Extensions.Options;
using API_DEVIO_COMPLETA.Configuration;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace WEBAPI.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<MeuDbContext>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IFornecedorRepository, FornecedorRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();

            services.AddScoped<INotificador, Notificador>();
            services.AddScoped<IFornecedorService, FornecedorService>();
            services.AddScoped<IProdutoService, ProdutoService>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUser, AspNetUser>();

            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            return services;
        }
    }
}
