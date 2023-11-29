using BookLibraryAPI.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookLibraryAPI.Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddDbContext<EFContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("PostgresSqlConnection"))
                );

        }
    }
}
