using FinalProjectService.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace FinalProject
{
    public class WeatherDateResult
    {

        public async static Task<CurrentConditions> GetWeather()
        {
            string json = null;
            string url = $"https://finalprojectcomp494.azurewebsites.net/api/weather/06";
            using (HttpClient http = new HttpClient())
            {
                  json = await http.GetStringAsync(url);
            }
            return Newtonsoft.Json.JsonConvert.DeserializeObject<CurrentConditions>(json);
        }

    }
}
