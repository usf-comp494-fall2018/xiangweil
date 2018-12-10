using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalWeather.Models
{
    public  class CurrentConditions
    {
        public long id { get; set; }                     //"id":0,
        public string observationTime { get; set; }     //"observationTime":"Last Updated on December 8, 12:56 PM CST",
        public string weather { get; set; }             //"weather":"Mostly Cloudy",
        public double tempF { get; set; }               //"tempF":31.5,
        public string relativeHumidity { get; set; }    //"relativeHumidity":"61%",
        public string windDir { get; set; }             //"windDir":"SSW",
        public double windMph { get; set; }             //"windMph":2.9,
        public string lastcheck { get; set; }           //lastcheck":"2018-12-08 07:33:32"}
      //  public List<ThreeDayForecast> ThreeDayForecast { get; set; }
    }

    public class ThreeDayForecast
    {
        public long id { get; set; }
        public long period { get; set; }
        public string icon { get; set; }
        public string title { get; set; }
        public string Fcttext { get; set; }
        public string lastcheck { get; set; }
    }


}

