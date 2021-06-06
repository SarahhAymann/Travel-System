namespace Travel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PhotoInTraveller : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Travellers", "Image", c => c.String());
            DropColumn("dbo.Travellers", "ConfrimPassword");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Travellers", "ConfrimPassword", c => c.String());
            DropColumn("dbo.Travellers", "Image");
        }
    }
}
