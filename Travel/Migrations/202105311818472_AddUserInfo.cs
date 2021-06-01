namespace Travel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserInfo : DbMigration
    {
        public override void Up()
        {
            Sql("Insert INTO UserInfoes (FirtsName, LastName, PhoneNumber,UserName,Password,UserRole) VALUES('Sarah', 'Ayman', '0110121088', 'Suso','111','Admin'); ");

        }

        public override void Down()
        {
        }
    }
}
