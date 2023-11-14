using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Globalization;

namespace Weather2.Classes
{
    public class City
    {        
        public Guid Id { get; set; }
        public string CityName { get; set; }
        public double Latt { get; set; } //szerokość geograficzna
        public double Long { get; set; } //długość geograficzna 
        public DateTime TimeStamp { get; set; }
    }

    public class CityLoader
    {
        public List<City> LoadCities(string xmlFilePath)
        {
            List<City> cityList = new List<City>();

            // Sprawdzenie, czy plik istnieje
            if (!File.Exists(xmlFilePath))
            {
                throw new FileNotFoundException("Plik XML nie został znaleziony.");
            }

            // Wczytanie pliku XML
            XDocument xdoc = XDocument.Load(xmlFilePath);

            // Przejście przez każdy element <city>
            foreach (XElement cityElement in xdoc.Descendants("city"))
            {
                City city = new City();
                city.CityName = cityElement.Element("name").Value;     
                string latitude = cityElement.Element("latitude").Value.Replace(',', '.');
                string longitude = cityElement.Element("longitude").Value.Replace(',', '.');
                // Ustawienie szerokości i długości geograficznej z uwzględnieniem kultury en-US
                city.Latt = double.Parse(latitude, CultureInfo.InvariantCulture);
                city.Long = double.Parse(longitude, CultureInfo.InvariantCulture);
                city.TimeStamp = DateTime.Now; // Ustawienie bieżącego znacznika czasu
                cityList.Add(city); // Dodanie miasta do listy
            }
            return cityList;
        }
    }
}