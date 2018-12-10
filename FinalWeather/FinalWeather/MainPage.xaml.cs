using FinalWeather.Models;
using Newtonsoft.Json;
using System;
using System.Collections;
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
using System.Globalization;
using Windows.UI.ViewManagement;

//using static FinalProject.WeatherDateResult;






// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace FinalWeather
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private ObservableCollection<FinalWeather.Models.ThreeDayForecast> _threedayWeather;
        private ObservableCollection<FinalWeather.Models.CurrentConditions> _todaysWeather;

        public MainPage()
        {
            InitializeComponent();

            _todaysWeather = new ObservableCollection<CurrentConditions>();
            _threedayWeather = new ObservableCollection<ThreeDayForecast>();

            //  getCurrentConditions();

            // Initialize collections
           // icCurrentWeatherData.ItemsSource = _todaysWeather;
 
        }
  

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var appView = Windows.UI.ViewManagement.ApplicationView.GetForCurrentView();
            appView.Title = "My final project - UWP Weather";
            string response;

            using (HttpClient client = new HttpClient())
            {
                string url = "https://finalprojectcomp494.azurewebsites.net/api/weather";
                response = await client.GetStringAsync(url);
            }
            // Deserialize the data from JSON response.

            var data = JsonConvert.DeserializeObject<List<ThreeDayForecast>>(response);
            //for (int i = 0; i < 3; i++)
            //{
            //    foreCast.Add(data[i]);
            //}

           
            TitleBlock0.Text = data[0].title;
            TitleBlock1.Text = data[1].title;
            TitleBlock2.Text = data[2].title;

            //DescriptionTextBlock.Text = data[0].lastcheck;
            DescriptionTextBlock0.Text = data[0].Fcttext;
            DescriptionTextBlock1.Text = data[1].Fcttext;
            DescriptionTextBlock2.Text = data[2].Fcttext;

            var iconcode = data[0].icon;
            string icon = String.Format("ms-appx:///Assets/" + iconcode + ".png");
            ResultImage0.Source = new BitmapImage(new Uri(icon, UriKind.Absolute));

            var iconcode1 = data[1].icon;
            string icon1 = String.Format("ms-appx:///Assets/" + iconcode1 + ".png");
            ResultImage1.Source = new BitmapImage(new Uri(icon1, UriKind.Absolute));

            var iconcode2 = data[2].icon;
            string icon2 = String.Format("ms-appx:///Assets/" + iconcode2 + ".png");
            ResultImage2.Source = new BitmapImage(new Uri(icon2, UriKind.Absolute));

            //for (int i = 0; i < 3; i++)
            //{
            //    var iconcodei = data[i].icon;
            //    string icon[i] = String.Format("ms-appx:///Assets/" + iconcode[i] + ".png");
            //    ResultImage[i].Source = new BitmapImage(new Uri(icon[i], UriKind.Absolute));
            //    TitleBlock[i].Text = data[i].title;
            //    DescriptionTextBlock[i].Text = data[i].Fcttext;
            //}



            // Call OpenWeatherMap API.
            string response1;

            using (HttpClient client = new HttpClient())
            {
                string url1 = "https://finalprojectcomp494.azurewebsites.net/api/weather/6";
                response1 = await client.GetStringAsync(url1);
            }


            // Deserialize the data from JSON response.
            // WeatherData = JsonConvert.DeserializeObject<OpenWeatherMapData>(response);
            var data1 = JsonConvert.DeserializeObject<CurrentConditions>(response1);
            currenTempBlock.Text = data1.tempF.ToString();
            currenweatherBlock.Text = data1.weather;
            currenHumidiBlock.Text = data1.relativeHumidity;
            //currenWDirBlock.Text = data1.windDir;
            currenMphBlock.Text = data1.windMph.ToString()+ " mph";
            currenTimeBlock.Text = data1.lastcheck;
        }


        // async void getCurrentConditions()
        public async static void getCurrentConditions(ObservableCollection<CurrentConditions> currentWeather)
        {


            // Call OpenWeatherMap API.
            string response;

            using (HttpClient client = new HttpClient())
            {
                string url = "https://finalprojectcomp494.azurewebsites.net/api/weather/6";
                response = await client.GetStringAsync(url);
            }


            // Deserialize the data from JSON response.
            // WeatherData = JsonConvert.DeserializeObject<OpenWeatherMapData>(response);
            var data = JsonConvert.DeserializeObject<CurrentConditions>(response);


            currentWeather.Add(data);

        }



        //public async static void getThreeDayForecast(ObservableCollection<ThreeDayForecast> foreCast)
        //// async void getThreeDayForecast()
        //{
        //    // Call OpenWeatherMap API.
        //    string response;

        //    using (HttpClient client = new HttpClient())
        //    {
        //        string url = "https://finalprojectcomp494.azurewebsites.net/api/weather";
        //        response = await client.GetStringAsync(url);
        //    }
        //    // Deserialize the data from JSON response.

        //    var data = JsonConvert.DeserializeObject<List<ThreeDayForecast>>(response);
        //    for (int i = 0; i < 3; i++)
        //    {
        //        foreCast.Add(data[i]);
        //    }

        //    TempTextBlock.Text = data.
        //    DescriptionTextBlock.Text = myWeather.weather[0].description;
        //    LocationTextBlock.Text = myWeather.name;
        //    //string icon = String.Format("ms-appx:///Assets/")
        //    // ResultTextBlock.Text = data[0].Fcttext.ToString();
        //    //ResultTextBlock.Text = data.Fcttext.ToString() + " 'F";
        //}


    }
}
