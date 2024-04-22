using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace XMLWeather
{
    public partial class ForecastScreen : UserControl
    {

        DayOfWeek currentDayOfWeek = DateTime.Now.DayOfWeek;
        string wantedDay;

        public ForecastScreen()
        {
            InitializeComponent();
            displayForecast();
        }

        public void displayForecast()
        {
            double min1Val = Convert.ToDouble(Form1.days[1].tempLow);
            double max1Val = Convert.ToDouble(Form1.days[1].tempHigh);

            double min2Val = Convert.ToDouble(Form1.days[2].tempLow);
            double max2Val = Convert.ToDouble(Form1.days[2].tempHigh);

            double min3Val = Convert.ToDouble(Form1.days[3].tempLow);
            double max3Val = Convert.ToDouble(Form1.days[3].tempHigh);

            double min4Val = Convert.ToDouble(Form1.days[4].tempLow);
            double max4Val = Convert.ToDouble(Form1.days[4].tempHigh);

            double min5Val = Convert.ToDouble(Form1.days[5].tempLow);
            double max5Val = Convert.ToDouble(Form1.days[5].tempHigh);

            double min6Val = Convert.ToDouble(Form1.days[6].tempLow);
            double max6Val = Convert.ToDouble(Form1.days[6].tempHigh);

            date1.Text = DetermineNextDay(CurrentScreen.nowDay.ToString());
            min1.Text = min1Val.ToString("0") + "°C";
            max1.Text = max1Val.ToString("0") + "°C";
            condition1.Text = Form1.DetermineCurrentCondition(1);

            date2.Text = DetermineNextDay(date1.Text);
            min2.Text = min2Val.ToString("0") + "°C";
            max2.Text = max2Val.ToString("0") + "°C";
            condition2.Text = Form1.DetermineCurrentCondition(2);

            date3.Text = DetermineNextDay(date2.Text);
            min3.Text = min3Val.ToString("0") + "°C";
            max3.Text = max3Val.ToString("0") + "°C";
            condition3.Text = Form1.DetermineCurrentCondition(3);

            date4.Text = DetermineNextDay(date3.Text);
            min4.Text = min4Val.ToString("0") + "°C";
            max4.Text = max4Val.ToString("0") + "°C";
            condition4.Text = Form1.DetermineCurrentCondition(4);

            date5.Text = DetermineNextDay(date4.Text);
            min5.Text = min5Val.ToString("0") + "°C";
            max5.Text = max5Val.ToString("0") + "°C";
            condition5.Text = Form1.DetermineCurrentCondition(5);

            date6.Text = DetermineNextDay(date5.Text);
            min6.Text = min6Val.ToString("0") + "°C";
            max6.Text = max6Val.ToString("0") + "°C";
            condition6.Text = Form1.DetermineCurrentCondition(6);
        }

        /// <summary>
        /// This is because I couldn't figure out day properly other than the first day (I could only do it for the 
        /// first day
        /// </summary>
        private string DetermineNextDay(string currentDay)
        {
            if(currentDay == "Monday")
            {
                return wantedDay = "Tuesday";
            }
            else if(currentDay == "Tuesday")
            {
                return wantedDay = "Wednesday";
            }
            else if(currentDay == "Wednesday")
            {
                return wantedDay = "Thursday";
            }
            else if (currentDay == "Thursday")
            {
                return wantedDay = "Friday";
            }
            else if (currentDay == "Friday")
            {
                return wantedDay = "Saturday";
            }
            else if (currentDay == "Saturday")
            {
                return wantedDay = "Sunday";
            }
            else
            {
                return wantedDay = "Monday";
            }
        }
        private void label3_Click(object sender, EventArgs e)
        {
            Form f = this.FindForm();
            f.Controls.Remove(this);

            CurrentScreen cs = new CurrentScreen();
            f.Controls.Add(cs);
        }

        private void citySearchLabel_Click(object sender, EventArgs e)
        {
            CurrentScreen.ChangeScreen(this, new CitySearch());
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
