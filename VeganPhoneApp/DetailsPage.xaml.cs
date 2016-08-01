using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using VeganPhoneApp.Resources;
using Newtonsoft.Json;
using VeganPhoneApp.Models;
using VeganPhoneApp.ViewModels;

namespace VeganPhoneApp
{
    public partial class DetailsPage : PhoneApplicationPage
    {
        // Constructor
        public DetailsPage()
        {
            InitializeComponent();

            //DataContext = App.ViewModel;
            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        // When page is navigated to set data context to selected item in list
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (DataContext == null)
            {
                string selectedIndex = "";
                if (NavigationContext.QueryString.TryGetValue("selectedItem", out selectedIndex))
                {
                    int index = int.Parse(selectedIndex);
                    DataContext = App.ViewModel.Items[index];
                }
            }
        }

        private void txtinput_TextChanged(object sender, RoutedEventArgs e)
        {

        }
      

      private void AddRating_Click(object sender, RoutedEventArgs e)
        {
            
        }
        
 /* {
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
      String rating = "";
      rating = txtinput.Text;
          
       try
      {
          //this.Items.Clear();
          if (e.Result != null)
          {
              var restaurants = JsonConvert.DeserializeObject<Restaurant[]>(e.Result);
              
                    
             foreach(Restaurant restaurant in restaurants)
             {

                   restaurant.NumberOfRatings++;
                   restaurant.SumOfRatings += Convert.ToInt32(rating);

             }                           

             
               MainViewModel MM = new MainViewModel();
              MM.IsDataLoaded = true;
          }
      }
        catch (Exception ex)
      {
          
      }
  
                
  }
  }
   */
     
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
    
