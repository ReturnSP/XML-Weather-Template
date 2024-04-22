using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Security.Cryptography.X509Certificates;

namespace XMLWeather
{
    public partial class CurrentScreen : UserControl
    {
        
        DayOfWeek currentDayOfWeek = DateTime.Now.DayOfWeek;
        public static string nowDay;

        public CurrentScreen()
        {
            InitializeComponent();
            DisplayCurrent();
        }

        public void DisplayCurrent()
        {
            double currentTemp = Convert.ToDouble(Form1.days[0].currentTemp);
            double minTemp = Convert.ToDouble(Form1.days[0].tempLow);
            double maxTemp = Convert.ToDouble(Form1.days[0].tempHigh);
            double humidityTemp = Convert.ToDouble(Form1.days[0].humidity);

            cityOutput.Text = Form1.days[0].location;
            currentOutput.Text = currentTemp.ToString("0") + "°C";
            minOutput.Text = minTemp.ToString("0") + "°C";
            maxOutput.Text = maxTemp.ToString("0") + "°C";

            currentConditionOutput.Text = Form1.DetermineCurrentCondition(0);
            currentDay.Text = currentDayOfWeek.ToString();

            nowDay = currentDayOfWeek.ToString();

            humidityOutput.Text = "Humidity is: " + humidityTemp.ToString("0") + "%";
        }

        private void forecastLabel_Click(object sender, EventArgs e)
        {
            Form f = this.FindForm();
            f.Controls.Remove(this);

            ForecastScreen fs = new ForecastScreen();
            f.Controls.Add(fs);
        }
        public static void ChangeScreen(object sender, UserControl next)
        {
            Form f; // will either be the sender or parent of sender

            if (sender is Form)
            {
                f = (Form)sender; //f is sender
            }
            else
            {
                UserControl current = (UserControl)sender;  //create UserControl from sender
                f = current.FindForm();                     //find Form UserControl is on
                f.Controls.Remove(current);                 //remove current UserControl
            }

            // add the new UserControl to the middle of the screen and focus on it
            next.Location = new Point((f.ClientSize.Width - next.Width) / 2,
            (f.ClientSize.Height - next.Height) / 2);
            f.Controls.Add(next);
            next.Focus();
        }

        private void citySearchLabel_Click(object sender, EventArgs e)
        {
            ChangeScreen(this, new CitySearch());
        }
    }
}
