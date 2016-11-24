using System;
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
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace VeganPhoneApp
{
    public partial class EditRestaurant : PhoneApplicationPage
    {
        public EditRestaurant()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            string parameter = string.Empty;
            if (NavigationContext.QueryString.TryGetValue("parameter", out parameter))
            {
                Name.Text = "Edit " + parameter;
            }

        }

        private async void Update_Click(object sender, RoutedEventArgs e)
        {
            HttpClient client = new HttpClient();


            //client.BaseAddress = new Uri("http://169.254.21.12");
            client.BaseAddress = new Uri("http://veganrestaurantrater.azurewebsites.net");



            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var restaurant = new Restaurant() { RestaurantName = restaurantNameInput.Text, Address = inputAddress.Text, Phone = Convert.ToInt32(inputphonenumber.Text) };

            HttpResponseMessage response = await client.PutAsJsonAsync("api/restaurant/" + restaurantNameInput.Text, restaurant);
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

        }
    }
}