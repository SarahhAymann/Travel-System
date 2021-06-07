namespace Travel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TripPosts", "Post_Like", c => c.Int(nullable: false));
            AddColumn("dbo.TripPosts", "Post_DisLike", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TripPosts", "Post_DisLike");
            DropColumn("dbo.TripPosts", "Post_Like");
        }
    }
}
