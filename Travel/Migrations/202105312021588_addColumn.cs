namespace Travel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addColumn : DbMigration
    {
        public override void Up()
        {
            Sql("ALTER TABLE UserInfoes ADD UserRole int; ");
        }
        
        public override void Down()
        {
        }
    }
}
