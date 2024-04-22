using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Xml;

namespace XMLWeather
{
    public partial class Form1 : Form
    {
        public static string currentCondition = "";
        //Create list to hold day objects
        public static List<Day> days = new List<Day>();

        //City Search
        string cityString = "Stratford, CA";

        public Form1()
        {
            InitializeComponent();

            ExtractForecast(cityString);
            ExtractCurrent();
            //DetermineCurrentCondition();

            // open weather screen for todays weather
            CurrentScreen cs = new CurrentScreen();
            this.Controls.Add(cs);
        }

        public static void ExtractForecast(string cityName)
        {
            XmlReader reader = XmlReader.Create("http://api.openweathermap.org/data/2.5/forecast/daily?q=" + cityName + "&mode=xml&units=metric&cnt=7&appid=3f2e224b815c0ed45524322e145149f0");

            while (reader.Read())
            {
                //Create a day object
                Day d = new Day();

                //fill day object with required data
                reader.ReadToFollowing("time");
                d.date = reader.GetAttribute("day");

                //Get current conditions
                reader.ReadToFollowing("symbol");
                d.condition = reader.GetAttribute("number");
                d.name = reader.GetAttribute("name");

                reader.ReadToFollowing("temperature");
                d.tempLow = reader.GetAttribute("min");
                d.tempHigh = reader.GetAttribute("max");

                reader.ReadToFollowing("humidity");
                d.humidity = reader.GetAttribute("value");
                //if day object not null add to the days list
                days.Add(d);
            }
        }
        public static string DetermineCurrentCondition(int dayNum)
        {
            int condition = Convert.ToInt16(Form1.days[dayNum].condition);

            ////Check what subsection condition falls under
            //Thunderstorm
            if (condition >= 200 && condition <= 232)
            {
                currentCondition = Form1.days[dayNum].name;
                return currentCondition;
            }
            //Drizzle
            else if (condition >= 300 && condition <= 321)
            {
                currentCondition = Form1.days[dayNum].name;
                return currentCondition;
            }
            //Rain
            else if (condition >= 500 && condition <= 531)
            {
                currentCondition = Form1.days[dayNum].name;
                return currentCondition;
            }
            //Snow
            else if (condition >= 600 && condition <= 622)
            {
                currentCondition = Form1.days[dayNum].name;
                return currentCondition;
            }
            //Clouds
            else if (condition >= 801 && condition <= 804)
            {
                currentCondition = Form1.days[dayNum].name;
                return currentCondition;
            }
            else if (condition == 800)
            {
                currentCondition = Form1.days[dayNum].name;
                return currentCondition;
            }
            else
            {
                currentCondition = "weather not real";
                return currentCondition;
            }
        }
        private void ExtractCurrent()
        {
            // current info is not included in forecast file so we need to use this file to get it
            XmlReader reader = XmlReader.Create("http://api.openweathermap.org/data/2.5/weather?q=Stratford,CA&mode=xml&units=metric&appid=3f2e224b815c0ed45524322e145149f0");

            //find the city and current temperature and add to appropriate item in days list
            reader.ReadToFollowing("city");
            days[0].location = reader.GetAttribute("name");

            reader.ReadToFollowing("temperature");
            days[0].currentTemp = reader.GetAttribute("value");
        }
    }
}
