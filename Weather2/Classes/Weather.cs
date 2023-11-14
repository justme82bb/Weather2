using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather2.Classes
{


    public class WeatherData
    {
        public Guid Id { get; set; }
        public Guid City_ID { get; set; }
        public string CityName { get; set; }
        public double CityLong { get; set; }
        public double CityLatt { get; set; }
       public float? Temp { get; set; }
       public float? Pressure { get; set; }
       public float? Humidity { get; set; }
       // public int? Visibility { get; set; }
       public float? WindSpeed { get; set; }
       public float? WindDirection { get; set; }
       // public decimal? Clouds { get; set; }
       // public float? Rain1h { get; set; }
      //  public float? Rain3h { get; set; }
       // public float? Snow1h { get; set; }
       // public float? Snow3h { get; set; }
       public DateTime? TimeStamp { get; set; }

        public WeatherData () 
        {
            CityName = string.Empty;
        }

        public WeatherData (City city)
        {
            City_ID = city.Id;
            CityName = city.CityName;
            CityLong = city.Long;
            CityLatt = city.Latt;
            Temp = null;
         }
    }


}
