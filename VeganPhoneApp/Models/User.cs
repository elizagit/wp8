using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeganPhoneApp.Models
{
    public enum UserType
    {
        RestaurantOwner, User
    }
   public class User
    {

        //p.k.
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public UserType? Usertype { get; set; }



        //navigation property 
        public virtual List<Restaurant> Restaurants { get; set; }
    }
}
