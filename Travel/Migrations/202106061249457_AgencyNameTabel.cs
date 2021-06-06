namespace Travel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AgencyNameTabel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TripPosts", "AgencyName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TripPosts", "AgencyName");
        }
    }
}
