namespace VeganWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSumOfRatingsAndNumberOfRatings : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Restaurants", "SumOfRatings", c => c.Int(nullable: false));
            AddColumn("dbo.Restaurants", "NumberOfRatings", c => c.Int(nullable: false));
            DropColumn("dbo.Restaurants", "Rating");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Restaurants", "Rating", c => c.Int(nullable: false));
            DropColumn("dbo.Restaurants", "NumberOfRatings");
            DropColumn("dbo.Restaurants", "SumOfRatings");
        }
    }
}
