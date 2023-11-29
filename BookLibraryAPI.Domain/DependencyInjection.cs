using BookLibraryAPI.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BookLibraryAPI.Domain
{
    public static class DependencyInjection
    {
        public static void AddDomain(this IServiceCollection services)
        {
            services.AddScoped<BookService>();
        }
    }
}
