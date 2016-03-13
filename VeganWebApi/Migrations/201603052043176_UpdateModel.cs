namespace VeganWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateModel : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Users", "Usertype");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Usertype", c => c.Int());
        }
    }
}
