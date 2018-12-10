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
        private ObservableCollection<FinalWeather.Models.List> currentWeatherData;
        private DispatcherTimer UpdateTimer;

        public MainPage()
        {
            this.InitializeComponent();
            UpdateTimer = new DispatcherTimer();
            UpdateTimer.Tick += new EventHandler(UpdateTimer_Tick);
            UpdateTimer.Interval = new TimeSpan(0, 12, 20);
            UpdateTimer.Start();

            // Initialize collections
            _threedayWeather = new ObservableCollection<FinalWeather.Models.ThreeDayForecast>();
            _todaysWeather = new ObservableCollection<FinalWeather.Models.CurrentConditions>();
             getCurrentConditions();

            // Initialize databindings
            icCurrentWeatherData.ItemsSource = currentWeatherData;
            icWeatherData.ItemsSource = allWeatherData;
            tbSelectedCityName.Text = SelectedCity;
            //   getThreeDayForecast();
        }

        //private async void ClickMeButton_Click(object sender, RoutedEventArgs e)
        //{
        //    //CurrentWeather myweather = await WeatherDateResult.GetWeather();
        //    //var geoWeather = new WeatherDateResult();
        //    string url = "https://finalprojectcomp494.azurewebsites.net/api/weather";
        //    //string url = "http://api.openweathermap.org/data/2.5/weather/?q=Islamabad,pk&APPID=853dbcea2a5b4eb495d21a3cef29d1af";
        //    HttpClient client = new HttpClient();

        //    string response = await client.GetStringAsync(url);

        //    var data = JsonConvert.DeserializeObject<List<ThreeDayForecast>>(response);

        //    ResultTextBlock.Text = data[0].fcttext.ToString() + " 'F";

        //}


        /// Asynchronous function to retrieve data from OpenWeatherMap API.

        // Handle responsedata
        OpenWeatherMapData WeatherData = new OpenWeatherMapData();
        ObservableCollection<FinalWeather.Models.List> allWeatherData;
        async void getCurrentConditions()
        {
          //  string weatherDataResp;
     
            // Call OpenWeatherMap API.
            string response;

            using (HttpClient client = new HttpClient())
            {
                string url = "https://finalprojectcomp494.azurewebsites.net/api/weather/6";
                response = await client.GetStringAsync(url);
            }
            // Deserialize the data from JSON response.
            WeatherData = JsonConvert.DeserializeObject<OpenWeatherMapData>(response);

            // Format date, time and image path and copy the results to allWeatherData
            foreach (var observationPoint in WeatherData.list)
            {
                System.DateTime timestamp = System.DateTimeOffset.FromUnixTimeSeconds(observationPoint.dt).DateTime;
                observationPoint.datetime = timestamp;
                observationPoint.weather[0].icon = $"/Assets/{observationPoint.weather[0].icon}.png";
                allWeatherData.Add(observationPoint);
            }
            //    ResultTextBlock.Text = data.tempF + " 'F";
          
            //  ResultTextBlock.Text = "Today weather " + data[0].tempF+ " F" ;
        }

        // Save weather data to file cache.



        async void getThreeDayForecast()
        {
            // Call OpenWeatherMap API.
            string response;

            using (HttpClient client = new HttpClient())
            {
                string url = "https://finalprojectcomp494.azurewebsites.net/api/weather";
                 response = await client.GetStringAsync(url);
            }
            // Deserialize the data from JSON response.

            var data = JsonConvert.DeserializeObject<List<ThreeDayForecast>>(response);

            ResultTextBlock.Text = data[0].Fcttext.ToString();
            //ResultTextBlock.Text = data.Fcttext.ToString() + " 'F";
        }

        private void UpdateTimer_Tick(Object sender, EventArgs e)
        {
            UpdateWeatherDataAsync();
        }

        /// <summary>
        /// Updates the weather data asynchronously.
        /// </summary>
        public async void UpdateWeatherDataAsync()
        {
            try
            {
               // imgLoading.Visibility = Visibility.Visible;

                // Clear the current data, call and await OpenWeatherMap API to return data
                // and cache the data 
                // and update the last update time.
                allWeatherData.Clear();
                await OpenWeatherMapFacade.GetWeatherDataAsync(SelectedCity, allWeatherData, ApiKey);
                OpenWeatherMapFacade.SaveWeatherDataToFileCache(SelectedCity, allWeatherData);
                OpenWeatherMapFacade.SaveLastUpdatedTime();
                SetCurrentWeatherData();
                imgLoading.Visibility = Visibility.Hidden;
            }
            catch (Exception e)
            {
                MessageBox.Show($"Error Occurred:\n{e.Message}\n\nStack:\n{e.StackTrace}",
                                "Error",
                                MessageBoxButton.OK,
                                MessageBoxImage.Error);
            }
            finally
            {
                imgLoading.Visibility = Visibility.Hidden;
            }
        }

        private void SetCurrentWeatherData()
        {
            if (currentWeatherData.Count > 0)
            {
                currentWeatherData.Clear();
            }

            if (allWeatherData.Count > 0)
            {
                currentWeatherData.Add(allWeatherData[0]);
            }
        }
    }
}
