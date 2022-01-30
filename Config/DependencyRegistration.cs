using WebAPIDI.Repository;

namespace WebAPIDI.Config;

public static class DependencyRegistration
{
    public static IServiceCollection RegisterRepositoryDependencies(this IServiceCollection services)
    {
        services.AddTransient<IWeatherRepository, WeatherRepository>();
        return services;
    }
    
}