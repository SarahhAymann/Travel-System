namespace Travel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropAdmin : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Admins");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirtsName = c.String(),
                        LastName = c.String(),
                        UserName = c.String(),
                        PhoneNumber = c.Int(nullable: false),
                        Email = c.String(),
                        Password = c.String(),
                        Image = c.Binary(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
    }
}
