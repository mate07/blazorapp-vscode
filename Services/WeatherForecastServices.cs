using System;
using System.Net.Http;
using System.Net.Http.Json;
using static WebApp.Pages.FetchData;

namespace WebAppServices
{
     public class WeatherForecastServices : IWeatherForecastServices
     {
          //Crear un contructor para el manejo de datos Null
          public WeatherForecastServices(HttpClient http)
          {
               Http = http;
          }

          //Incorporación para el sobrenombre Http
          public HttpClient Http { get; set; }

          //Creando metodo asincronico para inyección de dependencias
          public async Task<WeatherForecast[]> GetWeatherForecasts()
          {
               return await Http.GetFromJsonAsync<WeatherForecast[]>("sample-data/weather.json");
          }

          // Crear interfaz para el manejo de la dependencia
          public interface IWeatherForecastServices
          {
               Task<WeatherForecast[]> GetWeatherForecasts();
          }
     }
}