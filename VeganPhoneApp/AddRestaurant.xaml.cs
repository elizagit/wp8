using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using VeganPhoneApp.Resources;
using Newtonsoft.Json;
using VeganPhoneApp.Models;
using VeganPhoneApp.ViewModels;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Windows.Media.Imaging;
using Microsoft.Phone.Tasks; // enables PhotoChooser Task
using System.IO; //enables access to MemoryStream

namespace VeganPhoneApp
{
    public partial class AddRestaurant : PhoneApplicationPage
    {
        public AddRestaurant()
        {
            InitializeComponent();
        }
       
       
        private async void AddRestaurant_Click(object sender, RoutedEventArgs e)
        {
            HttpClient client = new HttpClient();


            client.BaseAddress = new Uri("http://169.254.21.12");



            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var restaurant = new Restaurant() { RestaurantName = restaurantNameInput.Text, Address = inputAddress.Text, Phone = Convert.ToInt32(inputphonenumber.Text) };

            HttpResponseMessage response = await client.PostAsJsonAsync("api/restaurant", restaurant);
            if (response.IsSuccessStatusCode)
            {
                Uri newRestaurant = response.Headers.Location;

                txtop.Text = "Thanks! Your restaurant has beed added";

                // HTTP PUT
                // HealthyHabits.Rating = 4;   // Update price
                // response = await client.PutAsJsonAsync(HealthyHabitsUrl, HealthyHabits);

                // HTTP DELETE
                //response = await client.DeleteAsync(HealthyHabitsUrl);
            }

        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }
    }
}