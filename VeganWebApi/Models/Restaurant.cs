using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VeganWebApi.Models
{
    public class Restaurant
    {   
        public Restaurant()
        {
            User = new User();
        }

        public Restaurant(string restaurantName, double longitude, double latitude)
        {
            this.RestaurantName = restaurantName;
            this.Latitude = latitude;
            this.Longitude = longitude;
        }
        
        //p.k.
        public int RestaurantID { get; set; }
        public string RestaurantName { get; set; }

        public double Longitude { get; set; }
        public double Latitude { get; set; }
        //Foreign Key
        public int UserID { get; set; }
        //Navigation key
        public virtual User User { get; set; }


    }
}