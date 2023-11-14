using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Weather2.Classes
{

    public class OpenWeatherService
    {
        const string OpenWeatherApiKey = "a1afd1ab9bd6dd89c955e2ed7a383aff"; // Podaj swój klucz API OpenWeather
        const string OpenWeatherApiUrl = "https://api.openweathermap.org/data/2.5/weather";

        public async Task<String> GetWeatherDataAsync(double latitude, double longitude)
        {
            using (var httpClient = new HttpClient())
            {
                try
                {
                    string url = $"{OpenWeatherApiUrl}?lat={latitude}&lon={longitude}&appid={OpenWeatherApiKey}&units=metric";
                    HttpResponseMessage response = await httpClient.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonContent = await response.Content.ReadAsStringAsync();
                        return jsonContent;
                    }
                    else
                    {
                        throw new Exception($"Błąd podczas pobierania danych pogodowych. Status: {response.StatusCode}");
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public async Task<List<WeatherData>> GetWeatherDatas (List<City> cityList)
        {
            OpenWeatherService openWeatherService = new OpenWeatherService();
            var weatherDataList = new List<WeatherData>();
            foreach (City city in cityList)
            {
                WeatherData weatherData = new WeatherData(city);
                weatherDataList.Add(weatherData);
                string jsonResponse = await openWeatherService.GetWeatherDataAsync(city.Latt, city.Long);
                //MessageBox.Show(jsonResponse);
                var cityData = JsonConvert.DeserializeObject<RootObject>(jsonResponse);
                weatherData.Temp = cityData.main.temp;
                weatherData.Pressure = cityData.main.pressure;
                weatherData.Humidity = cityData.main.humidity;
                weatherData.WindSpeed = cityData.wind.speed;
                weatherData.WindDirection = cityData.wind.deg;
                weatherDataList.Add(weatherData);
             }
            return weatherDataList;
        }
    }


}
///Przykład pełnej odpowiedzi {"coord":{"lon":21.0067,"lat":52.232},"weather":[{"id":800,"main":"Clear","description":"clear sky","icon":"01n"}],"base":"stations","main":{"temp":8.96,"feels_like":7.93,"temp_min":8.15,"temp_max":9.66,"pressure":1011,"humidity":78},"visibility":10000,"wind":{"speed":2.06,"deg":170},"clouds":{"all":0},"dt":1699386093,"sys":{"type":2,"id":2035775,"country":"PL","sunrise":1699335688,"sunset":1699369068},"timezone":3600,"id":756135,"name":"Warsaw","cod":200}