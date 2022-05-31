using JackStore.Repository.Concrete;
using JackStore.Repository.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace JackStore.WebApp
{
    public static class DiRepositoryExtension
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IRepCategoriaProduto, RepCategoriaProduto>();
            services.AddScoped<IRepProduto, RepProduto>();
        }
    }
}