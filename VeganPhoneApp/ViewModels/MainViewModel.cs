using VeganPhoneApp.Resources;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net;
using System.Net.NetworkInformation;
using System.Collections.Generic;
using Newtonsoft.Json;
using VeganPhoneApp.Models;
using System.Windows;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;


namespace VeganPhoneApp.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
       
        
        public MainViewModel()
        {
            /* var hostnames = Windows.Networking.Connectivity.NetworkInformation.GetHostNames();  //code to check the internal address of WP8E
             foreach (var hn in hostnames)
             {
                 if (hn.IPInformation != null)
                 {
                     string ipAddress = hn.DisplayName;
                 }
             } */
            this.Items = new ObservableCollection<ItemViewModel>();

        }

        /// <summary>
        /// A collection for ItemViewModel objects.
        /// </summary>
        public ObservableCollection<ItemViewModel> Items { get; private set; }

        public bool IsDataLoaded
        {
            get;
            set;
        }

     

        /// <summary>
        /// Creates and adds a few ItemViewModel objects into the Items collection.
        /// </summary>
        public async void LoadData()
        {

           HttpClient client = new HttpClient();
            

                client.BaseAddress = new Uri("http://169.254.21.12");

                var url = "api/Restaurant";

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(url);

                
                    var data = response.Content.ReadAsStringAsync();
                    var yourResult= JsonConvert.DeserializeObject<Restaurant[]>(data.Result.ToString());
                

            int id = 0;

            foreach (var item in yourResult )
            {
                this.Items.Add(new ItemViewModel()
                {
                    ID = (id++).ToString(),
                    LineOne = item.RestaurantName,
                 
                    LineTwo = item.Rating.ToString(),
                    LineThree = item.NumberOfRatings.ToString(),
                    LineFour = item.SumOfRatings.ToString(),
                    LineFive = item.Address.ToString(),
                    LineSix = item.Phone.ToString()
                    
                    
                    
                   
                });
            }

            this.IsDataLoaded = true;

           /* var HealthyHabits = new Restaurant() { RestaurantID = 33, RestaurantName = "Heathy Habits", Rating = 9, SumOfRatings = 1, NumberOfRatings = 1 };
            response = await client.PostAsJsonAsync("api/restaurants", HealthyHabits);
            if (response.IsSuccessStatusCode)
            {
                Uri HealthyHabitsUrl = response.Headers.Location;

                // HTTP PUT
                HealthyHabits.Rating = 4;   // Update price
                response = await client.PutAsJsonAsync(HealthyHabitsUrl, HealthyHabits);

                // HTTP DELETE
                response = await client.DeleteAsync(HealthyHabitsUrl);
            }*/
        }
                     

                    
                
/*
                // HTTP POST
                var HappyHippo = new Restaurant() { RestaurantName = "Happy Hippo", RestaurantID = 22, Rating = 7, NumberOfRatings = 1, SumOfRatings = 7 };
                response = await client.PostAsJsonAsync("api/restaurant", HappyHippo);
                if (response.IsSuccessStatusCode)
                {
                    Uri HappyHippoUrl = response.Headers.Location;

                    // HTTP PUT
                    HappyHippo.Rating = 4;   // Update rating
                    response = await client.PutAsJsonAsync(HappyHippoUrl, HappyHippo);

                    // HTTP DELETE
                    response = await client.DeleteAsync(HappyHippoUrl);
                }
            }
        }
    
       /*     if (this.IsDataLoaded == false)
            {
                //this.Items.Clear();
                //this.Items.Add(new ItemViewModel() { ID = "0", LineOne = "Please Wait...", LineTwo = "Please wait while the catalog is downloaded from the server.", LineThree = null });
                WebClient webClient = new WebClient();
                webClient.Headers["Accept"] = "application/json";
                webClient.DownloadStringCompleted += new DownloadStringCompletedEventHandler(webClient_DownloadCatalogCompleted); //initiates event handler
                webClient.DownloadStringAsync(new Uri(@"http://169.254.21.12/api/Restaurant"));  //this gets data from VeganWebApi and passes it to DownloadStringCompletedEventArgs e
               
            }
        }

        private void webClient_DownloadCatalogCompleted(object sender, DownloadStringCompletedEventArgs e)  //sender is the object in XAML that the handler is attached to.  e is the data that is sent. 
        // DownloadStringCompletedEventArgs gets the data that is downloaded by the DownloadStringAsync method.
        {
            
            try
            {
                //this.Items.Clear();
                if (e.Result != null)
                {
                    //var users = JsonConvert.DeserializeObject<User[]>(e.Result);
                    var restaurants = JsonConvert.DeserializeObject<Restaurant[]>(e.Result);
                    int id = 0;
                   
                   
                    //foreach (User user in users)
                    foreach (Restaurant restaurant in restaurants)
                    {
                        this.Items.Add(new ItemViewModel()
                        {
                            ID = (id++).ToString(),

                            //LineOne = user.UserName,
                            LineOne = restaurant.RestaurantName,
                            //LineTwo = user.Password,
                            LineTwo = restaurant.Rating.ToString()
                            //LineThree = restaurant.Rating.ToString(),

                            

                        });
                    }
                     
                    this.IsDataLoaded = true;
                }
            }
            catch (Exception ex)
            {
                this.Items.Add(new ItemViewModel()
                {
                    ID = "0",
                    LineOne = "An Error Occurred",
                    LineTwo = String.Format("The following exception occured: {0}", ex.Message),
                    LineThree = String.Format("Additional inner exception information: {0}", ex.InnerException.Message)

                });
            }
        }

      /*   private Rating _newRating;
      /// <summary>
      /// Sample ViewModel property; this property is used in the view to display its value using a Binding.
      /// </summary>
      /// <returns></returns>
      public string NewRating
      {
          get
          {
              return _newRating;
          }
          set
          {
              if (value != _newRating)
              {
                  _newRating = value;
                  NotifyPropertyChanged("NewRating");
              }
          }
      }
 
        */

        public event PropertyChangedEventHandler PropertyChanged; //an event declaration of delegate type PropertyChangedEventHandler
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}