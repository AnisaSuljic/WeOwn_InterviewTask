using WeOwnApplication.Interfaces_Repository;
using WeOwnApplication.Interfaces_Service;
using WeOwnApplication.Services;
using WeOwnInfra.Repositories;

namespace WeOwnAPI.Extensions
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IMovieAndTvShowService, MovieAndTvShowService>();
            services.AddScoped<IMovieAndTvShowRepository, MovieAndTvShowRepository>();

            return services;

        }
    }
}
