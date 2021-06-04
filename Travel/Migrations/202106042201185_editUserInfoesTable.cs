namespace Travel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editUserInfoesTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserInfoes", "Image", c => c.String());
            AddColumn("dbo.UserInfoes", "UserRole", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserInfoes", "UserRole");
            DropColumn("dbo.UserInfoes", "Image");
        }
    }
}
