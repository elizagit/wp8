namespace VeganWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingRatingPropertyToRestaurant : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Restaurants", "Rating", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Restaurants", "Rating");
        }
    }
}
