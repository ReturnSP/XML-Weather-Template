using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XMLWeather
{
    public partial class CitySearch : UserControl
    {
        string searchedCity;
        public CitySearch()
        {
            InitializeComponent();
        }

        private void cityForecast()
        {
            cityInput.Text = searchedCity;

            Form1.days.Clear();
            Form1.ExtractForecast(searchedCity);


        }
        private void forecastLabel_Click(object sender, EventArgs e)
        {
            CurrentScreen.ChangeScreen(this, new ForecastScreen());
        }

        private void label3_Click(object sender, EventArgs e)
        {
            CurrentScreen.ChangeScreen(this, new CurrentScreen());
        }
    }
}
