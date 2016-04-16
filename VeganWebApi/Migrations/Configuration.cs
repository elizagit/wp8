namespace VeganWebApi.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using VeganWebApi.Models;
    using System.Collections.Generic;
    
   
    

    internal sealed class Configuration : DbMigrationsConfiguration<VeganWebApi.Models.VeganWebApiContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
         
        }

        protected override void Seed(VeganWebApi.Models.VeganWebApiContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
         
    // 
            var users = new List<User>
        {
                new User { UserName = "Carson", Password = "5647hsns" },
                new User { UserName = "Meredith", Password = "Alonso"    },
                new User { UserName = "Arturo",   Password = "Anand"     }
            
            };
            users.ForEach(s => context.Users.AddOrUpdate(u => u.UserName, s));
            context.SaveChanges();  

           /* context.Users.AddOrUpdate(u => u.UserID,
                new User()
                {
                   
                    UserName = "Johanna",
                    Password = "I am a live",
                    UserID = 1

                },

                new User()
                {
                    
                    UserName = "Calinda",
                    Password = "Buttercups",
                    UserID = 2

                },
                new User()
                {
                    
   *+               UserName = "Bonnie",
                    Password = "OverUnder",
                    UserID = 3
                }
                );*/

            var restaurants = new List<Restaurant>
            {
             new Restaurant

             {  UserID = users.Single(s => s.UserName == "Carson").UserID,
                 RestaurantName = "Happy Foods",
                 Longitude = 45.4,
                 Latitude = 51.2,
                 Rating = 10
               

             },

            
            
             new Restaurant

             {  UserID = users.Single(s => s.UserName == "Carson").UserID,
                 RestaurantName = "Cornucopia",
                 Longitude = 45.4,
                 Latitude = 51.2,
                  Rating = 8
               

             },
             
             new Restaurant

             {  UserID = users.Single(s => s.UserName == "Meredith").UserID,
                 RestaurantName = "Vegan as it should be",
                 Longitude = 45.4,
                 Latitude = 51.2,
                  Rating = 10
               

             }
            };
            restaurants.ForEach(s => context.Restaurants.AddOrUpdate(r => r.RestaurantName, s));
            context.SaveChanges();
         
            
            

                
 



         

               
        }
    }
}
