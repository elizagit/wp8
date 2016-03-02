﻿using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace VeganWebApi.Models
{
    public class VeganWebApiContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public VeganWebApiContext() : base("name=VeganWebApiContext")
        
        { // code that allows SQL queries that EF generates to be traced
           // this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }
        
        public DbSet<VeganWebApi.Models.User> Users { get; set; }

        public DbSet<VeganWebApi.Models.Restaurant> Restaurants { get; set; }
      
    }
}
