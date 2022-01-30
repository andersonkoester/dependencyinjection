namespace WebAPIDI.Repository;

public class WeatherRepository : IWeatherRepository
{
    public WeatherForecast GetWeatherByCity(string city)
    {
        return new WeatherForecast
        {
            Date = DateTime.Now.AddDays(5),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = "Freezing"
        };
    }
}