using Domain.Ports;
using Infra.Data.Context;
using Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.Data
{
    public static class InfraDataExtensions
    {
        public static IServiceCollection AddDataBaseInMemoryService(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase("test"));
            services.AddScoped<IMovieRepository, MovieRepository>();
            return services;
        }
    }
}