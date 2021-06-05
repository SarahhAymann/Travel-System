namespace Travel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Returnimage : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserInfoes", "Image", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserInfoes", "Image", c => c.Byte(nullable: false));
        }
    }
}
