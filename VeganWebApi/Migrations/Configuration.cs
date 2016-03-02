namespace VeganWebApi.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using VeganWebApi.Models;

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
               context.Users.AddOrUpdate(u => u.UserID,
              
            new User{UserID= 1,UserName="Alexander",Password =""},
             new User{UserID= 2,UserName="Barney",Password =""},
             new User{UserID= 3,UserName="Clementine",Password = ""},
            new User{UserID= 4,UserName="Daria",Password = ""},
             new User{UserID= 5,UserName="Elizabeth",Password = ""},
             new User{UserID= 6,UserName="Francis",Password = ""},
            new User{UserID= 7,UserName="Georgia",Password = ""},
             new User{UserID= 8,UserName="Henrietta",Password = ""}
            
        );
               context.Restaurants.AddOrUpdate(r => r.RestaurantID,
               new Restaurant { RestaurantID = 1050, RestaurantName = "The Brick Room", Longitude = 32.1, Latitude = 21.9, UserID = 1 },
               new Restaurant { RestaurantID = 2050, RestaurantName = "Cornucopia", Longitude = 33.8, Latitude = 42.8, UserID =2 },
              new Restaurant { RestaurantID = 3050, RestaurantName = "Happy Foods", Longitude = 53.1, Latitude = 82.9, UserID = 3 },
           new Restaurant { RestaurantID = 4050, RestaurantName = "The Happy Pear", Longitude = 82.9, Latitude = 32.2, UserID =4 },
              new Restaurant { RestaurantID = 5050, RestaurantName = "Sova Vegan", Longitude = 33.1, Latitude = 27.4, UserID = 5 },
                new Restaurant { RestaurantID = 6050, RestaurantName = "Vegan As It Should Be", Longitude = 39.1, Latitude = 11, UserID = 6 },
               new Restaurant { RestaurantID = 7050, RestaurantName = "Vegan For The Animals", Longitude = 19.1, Latitude = 10.9, UserID = 7 }
               );
        }
    }
}
