namespace Travel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TripPostTabel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TripPosts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TripTitle = c.String(),
                        TripDetails = c.String(),
                        PostDate = c.DateTime(nullable: false),
                        TripDate = c.DateTime(nullable: false),
                        TripDestination = c.String(),
                        TripImage = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TripPosts");
        }
    }
}
