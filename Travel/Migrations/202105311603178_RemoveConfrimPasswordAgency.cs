namespace Travel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAdminTable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Agencies", "ConfrimPassword");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Agencies", "ConfrimPassword", c => c.String());
        }
    }
}
