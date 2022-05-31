using JackStore.Common;
using JackStore.Data.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JackStore.WebApp
{
    public static class EntityFrameworkExtension
    {
        public static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString(AppConfiguration.ConnectionStringTag);

            // contexto principal do Entity Framework
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(connectionString, opt => opt.MigrationsAssembly(typeof(BaseEntityMap<>).Assembly.FullName));
            });

            // contexto Identity do entity framework
            services.AddDbContext<ApplicationIdentityDbContext>(options =>
            {
                options.UseSqlServer(connectionString, assembly => assembly.MigrationsAssembly(typeof(ApplicationIdentityDbContext).Assembly.FullName));
            });
        }
    }
}