using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather2.Classes
{
    public class WeatherDB
    {
        private string connectionString = @"Data Source=NEXTNB04\SQLEXPRESS2019;Initial Catalog=WeatherDB2;User ID=sa;Password=Al1c310";
        private string tableName = "CurrentWeather_" + DateTime.Now.ToString("yyyy_MM_dd");
        public void CheckAndCreateTable()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Tworzenie nazwy tabeli w formacie CurrentWeather_DD_MM_YYYY          

                // Sprawdzenie, czy tabela o danej nazwie już istnieje
                string checkTableQuery = "SELECT * FROM sys.tables WHERE name = @tableName";

                using (SqlCommand cmd = new SqlCommand(checkTableQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@tableName", tableName);
                    object result = cmd.ExecuteScalar();
                    if (result == null) // Jeśli tabela nie istnieje
                    {
                        CreateTableCurrentWeather(DateTime.Now);
                    }

                }
            }
        }
        private void CreateTableCurrentWeather(DateTime date)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string createTableQuery = $@"CREATE TABLE {tableName} 
                                   (
                                       Id UNIQUEIDENTIFIER PRIMARY KEY,
                                       IdCity UNIQUEIDENTIFIER,
                                       Cityname NVARCHAR(255),
                                       Citylong float,
                                       Citylatt float,
                                        
                                       Temp float, 
                                       Feel_like float,
                                       Pressure float,
                                       Humidity float, 
                                       Visibility float,                                         
                                       WindSpeed float, 
                                       WindDirection float, 
                                       Clouds float,
                                       Rain1h float,
                                       Rain3h float,
                                       Snow1h float,
                                       Snow3h float,
                                       TimeStamp DATETIME
                                   );";

                using (SqlCommand cmd = new SqlCommand(createTableQuery, connection))
                {
                    cmd.ExecuteNonQuery();

                }
                connection.Close();
            }
        }
      
        public List<WeatherData> LoadCities (List<City> cityList)
        {
            var weatherDataList = new List<WeatherData>();
            foreach (City city in cityList)
            {
                WeatherData weatherData = new WeatherData(city);
                weatherDataList.Add(weatherData);
            }
            return weatherDataList;
        }

        public void SaveWeatherList (List<WeatherData> weatherDataList)
        {
            CheckAndCreateTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                foreach (var data in weatherDataList)
                {
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandType = CommandType.Text;
                        command.CommandText = $"INSERT INTO {tableName} (Id, idCity, cityname, citylong, citylatt, temp, pressure, windspeed, humidity, winddirection, TimeStamp) VALUES (NEWID(), @City_ID, @CityName, @CityLong, @CityLatt, @Temp, @Pressure, @Humidity,@WindSpeed,  @WindDirection, GETDATE())";

                        // Dodaj parametry z obiektu WeatherData
                        command.Parameters.AddWithValue("@City_ID", data.City_ID);
                        command.Parameters.AddWithValue("@CityName", data.CityName);
                        command.Parameters.AddWithValue("@CityLong", data.CityLong);
                        command.Parameters.AddWithValue("@CityLatt", data.CityLatt);
                        command.Parameters.AddWithValue("@Temp", data.Temp);
                        command.Parameters.AddWithValue("@Pressure", data.Pressure);
                        command.Parameters.AddWithValue("@Humidity", data.Humidity);
                        command.Parameters.AddWithValue("@WindSpeed", data.WindSpeed);
                        command.Parameters.AddWithValue("@WindDirection", data.WindDirection);                      
                        command.ExecuteNonQuery();
                    }
                }

                connection.Close();
            }





        }

        public List<WeatherData> LoadWeatherList(DateTime date)
        {
            List<WeatherData> weatherDataList = new List<WeatherData>();

            // Formatowanie nazwy tabeli zgodnie z datą
            string tableName = $"CurrentWeather_{date:yyyy_MM_dd}";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string commandText = $"SELECT Id, IdCity, CityName, CityLong, CityLatt, Temp, Pressure, Humidity, WindSpeed, WindDirection, TimeStamp FROM {tableName}";
                MessageBox.Show(commandText);
                using (SqlCommand command = new SqlCommand(commandText, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var weatherData = new WeatherData
                            {
                                Id = reader.GetGuid(reader.GetOrdinal("Id")),
                                City_ID = reader.GetGuid(reader.GetOrdinal("IdCity")),
                                CityName = reader.GetString(reader.GetOrdinal("CityName")),
                                CityLong = reader.GetDouble(reader.GetOrdinal("CityLong")),
                                CityLatt = reader.GetDouble(reader.GetOrdinal("CityLatt")),
                                Temp = reader.IsDBNull(reader.GetOrdinal("Temp")) ? (float?)null : (float)reader.GetDouble(reader.GetOrdinal("Temp")),                         
                                Pressure = reader.IsDBNull(reader.GetOrdinal("Pressure")) ? (float?)null : (float)reader.GetDouble(reader.GetOrdinal("Pressure")),
                                
                                 Humidity = reader.IsDBNull(reader.GetOrdinal("Humidity")) ? (float?)null : (float)reader.GetDouble(reader.GetOrdinal("Humidity")),
                                WindSpeed = reader.IsDBNull(reader.GetOrdinal("WindSpeed")) ? (float?)null : (float)reader.GetDouble(reader.GetOrdinal("WindSpeed")),
                                WindDirection = reader.IsDBNull(reader.GetOrdinal("WindDirection")) ? (float?)null : (float)reader.GetDouble(reader.GetOrdinal("WindDirection")),
                                TimeStamp = reader.GetDateTime(reader.GetOrdinal("TimeStamp"))

                            };
                            weatherDataList.Add(weatherData);
                        }
                    }
                }
                connection.Close();
            }

            return weatherDataList;
        }

        public List<WeatherData> LoadWeatherDataInRange(DateTime startDate, DateTime endDate)
        {
            List<WeatherData> allWeatherData = new List<WeatherData>();

            for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
            {
                               allWeatherData.AddRange(LoadWeatherList(date));
            }

            return allWeatherData;
        }

    }
}
