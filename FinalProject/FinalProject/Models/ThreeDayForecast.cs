using System;
using System.Collections.Generic;

namespace FinalProjectService.Models
{
    public partial class ThreeDayForecast
    {
        public long id { get; set; }
        public long period { get; set; }
        public string icon { get; set; }
        public string title { get; set; }
        public string fcttext { get; set; }
        public string lastcheck { get; set; }
    }
}
