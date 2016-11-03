using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeganPhoneApp.Models
{
    public class Restaurant
    {
        public int RestaurantID { get; set; }
        public string RestaurantName { get; set; }
        public int Rating { get; set; }
        public int NumberOfRatings { get; set; }
        public int SumOfRatings { get; set; }

        public string Address { get; set; }

        //public byte[] Image { get; set; }

        public int Phone { get; set; }
    }
}
