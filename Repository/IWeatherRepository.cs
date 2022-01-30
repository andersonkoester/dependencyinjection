namespace WebAPIDI.Repository;

public interface IWeatherRepository
{
    public WeatherForecast GetWeatherByCity(string city);
}