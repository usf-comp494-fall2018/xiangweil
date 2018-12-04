using FinalProjectService.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using static FinalProject.WeatherDateResult;






// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace FinalProject
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private ObservableCollection<WeatherDateResult> _todaysWeather;
        //   ObservableCollection<WeatherDateResult> _results;
        public MainPage()
        {
            this.InitializeComponent();
            getThreeDayForecast();
        }

        private async void ClickMeButton_Click(object sender, RoutedEventArgs e)
        {
            //CurrentWeather myweather = await WeatherDateResult.GetWeather();
            //var geoWeather = new WeatherDateResult();
            var data =  await WeatherDateResult.GetWeather();
            if (data != null)
            {
                ResultTextBlock.Text = $"{data.Id}";
            }
            
        }

        async void getCurrentConditions()
        {
             string url = "https://finalprojectcomp494.azurewebsites.net/api/weather/06";
            //string url = "http://api.openweathermap.org/data/2.5/weather/?q=Islamabad,pk&APPID=853dbcea2a5b4eb495d21a3cef29d1af";
            HttpClient client = new HttpClient();

            string response = await client.GetStringAsync(url);

            var data = JsonConvert.DeserializeObject<CurrentConditions>(response);

            ResultTextBlock.Text = data.TempF.ToString() + " 'F";
        }

        async void getThreeDayForecast()
        {
            string url = "https://finalprojectcomp494.azurewebsites.net/api/weather";
            //string url = "http://api.openweathermap.org/data/2.5/weather/?q=Islamabad,pk&APPID=853dbcea2a5b4eb495d21a3cef29d1af";
            HttpClient client = new HttpClient();

            string response = await client.GetStringAsync(url);

            var data = JsonConvert.DeserializeObject<List<ThreeDayForecast>>(response);
         
            ResultTextBlock.Text = data.First().fcttext.ToString() + " 'F";
        }

    }
}
