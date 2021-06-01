namespace Travel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAgencyTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Agencies",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirtsName = c.String(),
                        LastName = c.String(),
                        UserName = c.String(),
                        PhoneNumber = c.Int(nullable: false),
                        Email = c.String(),
                        Password = c.String(),
                        ConfrimPassword = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Agencies");
        }
    }
}
