using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Weather2.Classes;

namespace Weather2
{
    public partial class Form2 : Form
    {
        private List<City> globalCityList = new List<City>();
        private List<WeatherData> globalWeatherDatas = new List<WeatherData>();

        public Form2()
        {
            InitializeComponent();
            dateTimeFrom.Value = DateTime.Now;
            dateTimeTo.Value = DateTime.Now;
        }

        private void buttonLoadWeather_Click(object sender, EventArgs e)
        {
            if (dateTimeFrom.Value <= dateTimeTo.Value)
            {

                globalWeatherDatas.Clear();
                WeatherDB db = new WeatherDB();
                DateTime dateToLoad = DateTime.Now;

                globalWeatherDatas = db.LoadWeatherDataInRange(dateTimeFrom.Value, dateTimeTo.Value);
                dataGridRaport.DataSource = null;
                dataGridRaport.DataSource = globalWeatherDatas;
            }
            else MessageBox.Show("Nieprawdiłowy zakres dat");
        }


    }
}
