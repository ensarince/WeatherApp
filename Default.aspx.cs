using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Web.Script.Serialization;
using System.Text.RegularExpressions;


public partial class _Default : System.Web.UI.Page
{
   
    public void GetWeatherInfo(object sender, EventArgs e)
    {
        try { 
        string appid = "********************************";
        string url = string.Format("*********************************", txt1City.Text,appid);

        using (WebClient client = new WebClient())
        {
            string json = client.DownloadString(url);
            WeatherInfo weatherınfo = (new JavaScriptSerializer()).Deserialize<WeatherInfo>(json);



            imgWeatherIcon.ImageUrl = string.Format("http://openweathermap.org/img/w/{0}.png", weatherınfo.list[0].weather[0].icon);
            lblCity_Country.Text = weatherınfo.city.name + "," + weatherınfo.city.country;  
            lblDescription.Text = weatherınfo.list[0].weather[0].description;
            lblTemp.Text = string.Format("{0} \u00B0" + "C", weatherınfo.list[0].main.temp);
            lblWinddirection.Text = string.Format("{0}\u00B0", weatherınfo.list[0].wind.deg);
            lblWindspeed.Text = string.Format("{0}" + " km/h", weatherınfo.list[0].wind.speed);
            lblPressure.Text = string.Format("{0}" + " P" , weatherınfo.list[0].main.pressure); 
            lblAvgTemp.Text = string.Format("{0} \u00B0" + "C", (weatherınfo.list[0].main.temp_min + weatherınfo.list[0].main.temp_max)/2);


            tableWeather.Visible = true;

        }
        }
        catch (Exception ex)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + ex.Message.ToString() + "');", true);

        }



    }
    
   

    public class WeatherInfo
    {
        public City city { get; set; }
        public List<List> list { get; set; }


        public class main
        {
            public double temp { get; set; }
            public double pressure { get; set; }
            public double humidity { get; set; }
            public double temp_min { get; set; }
            public double temp_max { get; set; }

        }
        public class wind
        {
            public double speed { get; set; }
            public double deg { get; set; }
        }
        public class City
        {
            public string name { get; set; }
            public string country { get; set; }

        }
        public class Weather
        {
            
            public string description { get; set; } // weather description
            public string icon { get; set; } // weather icon id
            public string main { get; set; } //weather condition

        }
        public class List
        {
            public double pressure { get; set; } //pressure hpa
            public double windspeed { get; set; } //windspeed km/h
            public double humidity { get; set; } //humidity %
            public List<Weather> weather { get; set; } //weather list
            public wind wind { get; set; }
            public main main { get; set; }


        }
      

    }
   
    

}
