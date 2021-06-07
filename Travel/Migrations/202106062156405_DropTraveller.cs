namespace Travel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropTraveller : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Travellers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Travellers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirtsName = c.String(),
                        LastName = c.String(),
                        UserName = c.String(),
                        PhoneNumber = c.Int(nullable: false),
                        Email = c.String(),
                        Password = c.String(),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
    }
}
