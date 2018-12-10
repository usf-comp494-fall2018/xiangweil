using System;
using System.Collections.Generic;

namespace FinalWeather.Models
{
    public  class ThreeDayForecast11
    {
        public long id { get; set; }
        public long period { get; set; }
        public string icon { get; set; }
        public string title { get; set; }
        public string Fcttext { get; set; }
        public string lastcheck { get; set; }
    }
}
