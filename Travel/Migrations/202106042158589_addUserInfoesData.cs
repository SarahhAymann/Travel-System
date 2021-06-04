namespace Travel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addUserInfoesData : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.UserInfoes", "Image");
            DropColumn("dbo.UserInfoes", "UserRole");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserInfoes", "UserRole", c => c.Int(nullable: false));
            AddColumn("dbo.UserInfoes", "Image", c => c.Binary());
        }
    }
}
