using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using VeganPhoneApp.Resources;
using VeganPhoneApp.ViewModels;
using VeganPhoneApp.Models;
using Newtonsoft.Json;
using System.Diagnostics;

namespace VeganPhoneApp
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Set the data context of the LongListSelector control to the sample data
            DataContext = App.ViewModel;

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        // Load data for the ViewModel Items
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (!App.ViewModel.IsDataLoaded)
            {
                App.ViewModel.LoadData();
            }
        }


        // Handle selection changed on LongListSelector
        private void MainLongListSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // If selected item is null (no selection) do nothing
            if (MainLongListSelector.SelectedItem == null)
                return;

            // Navigate to the new page
            NavigationService.Navigate(new Uri("/DetailsPage.xaml?selectedItem=" + (MainLongListSelector.SelectedItem as ItemViewModel).ID, UriKind.Relative));

            // Reset selected item to null (no selection)
            MainLongListSelector.SelectedItem = null;
        }

       
             private void SearchRestaurants_Click(object sender, RoutedEventArgs e)
        {
            SendRequest();
        }
         void SendRequest()
        {
            string API_KEY = "-";
            string RESULT_FORMAT = "xml";
            string url = string.Format("http://169.254.21.12/api/Restaurants", API_KEY, RESULT_FORMAT);
            WebClient wc = new WebClient();
            wc.DownloadStringAsync(new Uri(url));
            wc.DownloadStringCompleted += DownloadStringCompleted;
        }

        void DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        { 
            String name = "";
            name = txtinput.Text;
          
             try
            {
                //this.Items.Clear();
                if (e.Result != null)
                {
                    var restaurants = JsonConvert.DeserializeObject<Restaurant[]>(e.Result);
                    int id = 0;

                      foreach (Restaurant restaurant in restaurants)
                    {
                        if(name == restaurant.RestaurantName)
                        {
                            txtop.Text = restaurant.Rating.ToString();
                        

                            

                        }
                    }
                     MainViewModel MM = new MainViewModel();
                    MM.IsDataLoaded = true;
                }
            }
              catch (Exception ex)
            {
                txtop.Text = "an error occurred";
            }
                
        }
        }
        

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
