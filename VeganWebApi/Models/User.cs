using System;
using System.Collections.Generic;


namespace VeganWebApi.Models
{
    public enum UserType 
    { 
        RestaurantOwner, User 
    }
    public class User
    {
       public User()
        {
            this.UserID = System.Threading.Interlocked.Increment(ref Counter);
        } 
       /* public User()
        {
            Restaurants = new List<Restaurant>();
        }*/

        public User(string userName, string password, UserType usertype)
        {
            this.UserName = userName;
            this.Password = password;
            this.Usertype = usertype;   //if user type is a RestaurantOwner then list of restaurant is mandatory
        }

        private static int Counter = 0;
        //p.k.
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public UserType? Usertype { get; set; }

   

       //navigation property 
        public virtual List<Restaurant> Restaurants { get; set; }
    }
}