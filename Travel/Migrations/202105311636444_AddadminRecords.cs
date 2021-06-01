namespace Travel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddadminRecords : DbMigration
    {
        public override void Up()
        {
            Sql("Insert INTO Admins (FirtsName, LastName, PhoneNumber) VALUES('Sarah', 'Ayman', '0110121088'); ");
            Sql(" Alter table Admins Add Photo nvarchar(100), AlternateText nvarchar(100) ");
            Sql("Update Admins set Photo = '~/Photos/SarahPic.png', AlternateText = 'SarahPic Photo' where Id = 1 ");
        }
        
        public override void Down()
        {
        }
    }
}
