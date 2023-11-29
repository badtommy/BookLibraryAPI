using BookLibraryAPI.Domain;
using MediatR.Extensions.FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace BookLibraryAPI.AppLayer
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAppLayer(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
            //services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);
            services.AddFluentValidation(new[] { typeof(DependencyInjection).Assembly });
            services.AddDomain();
            return services;
        }
    }
}
