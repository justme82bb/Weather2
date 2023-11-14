using System.Windows.Forms;
using System.Xml.Linq;
using Weather2.Classes;
using System.Data.SqlClient;

namespace Weather2
{
    public partial class Form1 : Form
    {
        private List<City> globalCityList = new List<City>();
        private List<WeatherData> globalWeatherDatas = new List<WeatherData>();

        public Form1()
        {
            InitializeComponent();
            labelLog.Text = "Uruchomienie : " + DateTime.Now;
        }


        private void ButtonGetCities_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Plik z miastami";
            openFileDialog.Filter = "Pliki XML (*.xml)|*.xml|Wszystkie pliki (*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    CityLoader cityLoader = new CityLoader();
                    globalCityList.Clear();
                    globalCityList = cityLoader.LoadCities(openFileDialog.FileName);
                    List<City> cities = cityLoader.LoadCities(openFileDialog.FileName);
                    dataGridView1.DataSource = globalCityList;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Wyst¹pi³ b³¹d podczas wczytywania miast: " + ex.Message);
                }
            }

            labelLog.Text = $"Plik {openFileDialog.FileName} zawiera {globalCityList.Count} miast";
            CityDB weatherDB2 = new CityDB();
            weatherDB2.SaveOrUpdateCities(globalCityList);

        }

        private void ButtonGetWeather_Click(object sender, EventArgs e)
        {
            globalWeatherDatas.Clear();
            globalCityList.Clear();

            CityDB citiesDB = new CityDB();
            WeatherDB weatherDB = new WeatherDB();

            globalCityList = citiesDB.LoadCities();
            globalWeatherDatas = weatherDB.LoadCities(globalCityList);


            dataGridView1.DataSource = null;
            dataGridView1.DataSource = globalWeatherDatas;




        }

        private async void buttonGetApi_Click(object sender, EventArgs e)
        {
            OpenWeatherService OWS = new OpenWeatherService();
            globalWeatherDatas = await OWS.GetWeatherDatas(globalCityList);

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = globalWeatherDatas;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            WeatherDB weatherDB = new WeatherDB();
            weatherDB.SaveWeatherList(globalWeatherDatas);


        }

        private void buttonRaport_Click(object sender, EventArgs e)
        {
            // Tworzenie nowej instancji drugiego formularza
            Form2 form2 = new Form2();

            // Otwieranie nowego formularza
            form2.Show();
        }
    }
}