namespace Travel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AgencyNameRequests : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PostsRequests", "AgencyName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PostsRequests", "AgencyName");
        }
    }
}
