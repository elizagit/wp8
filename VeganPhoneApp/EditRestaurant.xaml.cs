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
           /* base.OnNavigatedTo(e);
            string parameter = string.Empty;
            if (NavigationContext.QueryString.TryGetValue("parameter", out parameter))
            {
                Name.Text = "Edit " + parameter;
            }*/

            string name = NavigationContext.QueryString["name"];
            Name.Text = "Edit " + name;
            string rating = NavigationContext.QueryString["rating"];
            Rating.Text = rating ;
            string numberofratings = NavigationContext.QueryString["numberofratings"];
            NumberOfRatings.Text = numberofratings;
            
            
            string sumofratings = NavigationContext.QueryString["sumofratings"];
            SumOfRatings.Text = sumofratings;
           
        }


        private async void Update_Click(object sender, RoutedEventArgs e)
        {
            HttpClient client = new HttpClient();


            //client.BaseAddress = new Uri("http://169.254.21.12");
            client.BaseAddress = new Uri("http://veganrestaurantrater.azurewebsites.net");



            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var restaurant = new Restaurant() { RestaurantName = restaurantNameInput.Text, Address = inputAddress.Text, Phone = Convert.ToInt32(inputphonenumber.Text), Rating = Convert.ToInt32(Rating.Text), NumberOfRatings = Convert.ToInt32(NumberOfRatings.Text), SumOfRatings = Convert.ToInt32(SumOfRatings.Text) };

            HttpResponseMessage response = await client.PutAsJsonAsync("api/restaurant/" + restaurantNameInput.Text, restaurant);
            if (response.IsSuccessStatusCode)
            {
                Uri newRestaurant = response.Headers.Location;

                txtop.Text = "Thanks! Your restaurant has been updated";

           
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }
    }
}