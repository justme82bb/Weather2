using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;


// Other using directives as necessary

namespace Weather2.Classes
{
    public class CityDB
    {
        private string connectionString = @"Data Source=NEXTNB04\SQLEXPRESS2019;Initial Catalog=WeatherDB2;User ID=sa;Password=Al1c310";
        public void SaveOrUpdateCities(List<City> cityList)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        foreach (var city in cityList)
                        {
                            if (CityExists(connection, transaction, city.CityName))
                            {
                                UpdateCity(connection, transaction, city);
                            }
                            else
                            {
                                AddCity(connection, transaction, city);
                            }
                        }

                        transaction.Commit();
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine(ex.Message);
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
        private bool CityExists(SqlConnection connection, SqlTransaction transaction, string cityName)
        {
            using (SqlCommand command = connection.CreateCommand())
            {
                command.Transaction = transaction;
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT COUNT(1) FROM cities WHERE Name = @Name";
                command.Parameters.AddWithValue("@Name", cityName);

                int count = Convert.ToInt32(command.ExecuteScalar());
                return count > 0;
            }
        }
        private void AddCity(SqlConnection connection, SqlTransaction transaction, City city)
        {
            using (SqlCommand command = connection.CreateCommand())
            {
                command.Transaction = transaction;
                command.CommandType = CommandType.Text;
                command.CommandText = @"
                    INSERT INTO cities (id, Name, Latt, Long, TimeStamp) 
                    VALUES (NEWID(), @Name, @Latt, @Long, @Time)";
                command.Parameters.AddWithValue("@Name", city.CityName);
                command.Parameters.AddWithValue("@Latt", city.Latt);
                command.Parameters.AddWithValue("@Long", city.Long);
                command.Parameters.AddWithValue("@Time", city.TimeStamp);

                command.ExecuteNonQuery();
            }
        }
        private void UpdateCity(SqlConnection connection, SqlTransaction transaction, City city)
        {
            using (SqlCommand command = connection.CreateCommand())
            {
                command.Transaction = transaction;
                command.CommandType = CommandType.Text;
                command.CommandText = @"
                    UPDATE cities 
                    SET Latt = @Latt, Long = @Long, TimeStamp = @Time 
                    WHERE Name = @Name";

                command.Parameters.AddWithValue("@Name", city.CityName);
                command.Parameters.AddWithValue("@Latt", city.Latt);
                command.Parameters.AddWithValue("@Long", city.Long);
                command.Parameters.AddWithValue("@Time", city.TimeStamp);

                command.ExecuteNonQuery();
            }
        }
        public List<City> LoadCities()
        {
            var cities = new List<City>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                {
                    connection.Open();
                    string query = "SELECT id, Name, Latt, Long, TimeStamp FROM cities";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var city = new City
                                {
                                    Id = reader.GetGuid(reader.GetOrdinal("id")),
                                    CityName = reader.GetString(reader.GetOrdinal("Name")),
                                    Latt = reader.GetDouble(reader.GetOrdinal("Latt")),
                                    Long = reader.GetDouble(reader.GetOrdinal("Long")),
                                    TimeStamp = reader.GetDateTime(reader.GetOrdinal("TimeStamp"))
                                };
                                cities.Add(city);
                            }
                        }
                    }
                    connection.Close();
                }
            }

            return cities;
        }

    }
}
    