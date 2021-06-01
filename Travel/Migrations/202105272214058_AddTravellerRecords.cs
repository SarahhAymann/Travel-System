namespace Travel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTravellerRecords : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Travellers (FirtsName, LastName ,PhoneNumber) VALUES('Lobna', 'ElNaggar','01001422878'); ");
            Sql("INSERT INTO Travellers (FirtsName, LastName ,PhoneNumber) VALUES('Sarah', 'Ayman','0110121088'); ");
        }
        
        public override void Down()
        {
        }
    }
}
