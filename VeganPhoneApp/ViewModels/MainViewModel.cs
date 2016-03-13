using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net;
using System.Net.NetworkInformation;
using VeganPhoneApp.Resources;
using System.Collections.Generic;
using Newtonsoft.Json;
using VeganPhoneApp.Models;

namespace VeganPhoneApp.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        const string apiUrl = @"http://www.localhost:40134/api/Users";
        public MainViewModel()
        {
            this.Users = new List<ItemViewModel>();
        }

        /// <summary>
        /// A collection for ItemViewModel objects.
        /// </summary>
        public List<ItemViewModel> Users { get; private set; }

        public bool IsDataLoaded
        {
            get;
            private set;
        }

        /// <summary>
        /// Creates and adds a few ItemViewModel objects into the Items collection.
        /// </summary>
        public void LoadData()
        {
            if (this.IsDataLoaded == false)
            {
                this.Users.Clear();
                this.Users.Add(new ItemViewModel() { UserID = "0", UserName = "Please Wait...", Password = "Please wait while the catalog is downloaded from the server.", UserType = null });
                WebClient webClient = new WebClient();
                webClient.Headers["Accept"] = "application/json";
                webClient.DownloadStringCompleted += new DownloadStringCompletedEventHandler(webClient_DownloadCatalogCompleted);
                webClient.DownloadStringAsync(new Uri(apiUrl));
            }
        }

        private void webClient_DownloadCatalogCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
                this.Users.Clear();
                if (e.Result != null)
                {
                    var books = JsonConvert.DeserializeObject<User[]>(e.Result);
                    int id = 0;
                    foreach (User user in users)
                    {
                        this.Users.Add(new ItemViewModel()
                        {
                            UserID = (id++).ToString(),
                            LineOne = user.Password,
                            LineTwo = user.UserName,
                           
                        });
                    }
                    this.IsDataLoaded = true;
                }
            }
            catch (Exception ex)
            {
                this.Users.Add(new ItemViewModel()
                {
                    UserID = "0",
                    LineOne = "An Error Occurred",
                    LineTwo = String.Format("The following exception occured: {0}", ex.Message),
                    LineThree = String.Format("Additional inner exception information: {0}", ex.InnerException.Message)
                });
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }



        public IEnumerable<User> users { get; set; }
    }
}