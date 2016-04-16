using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeganPhoneApp.Models
{
    public class Restaurant
    {

        /*
        public Restaurant(string restaurantName, double longitude, double latitude)
        {
            this.RestaurantName = restaurantName;
            this.Latitude = latitude;
            this.Longitude = longitude;
        }
        */
        //Primary key
        public int RestaurantID { get; set; }
        public string RestaurantName { get; set; }

        public double Longitude { get; set; }
        public double Latitude { get; set; }

        public int Rating { get; set; }
        //Foreign Key
        public int UserID { get; set; }
        //Navigation key
        public virtual User User { get; set; }


    }
}
