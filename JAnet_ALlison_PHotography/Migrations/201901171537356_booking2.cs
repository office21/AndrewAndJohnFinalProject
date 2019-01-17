namespace JAnet_ALlison_PHotography.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class booking2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bookings", "PhotoType", c => c.Int(nullable: false));
            AddColumn("dbo.Bookings", "Quantity", c => c.Int(nullable: false));
            DropColumn("dbo.Bookings", "TimeSlot");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Bookings", "TimeSlot", c => c.Int(nullable: false));
            DropColumn("dbo.Bookings", "Quantity");
            DropColumn("dbo.Bookings", "PhotoType");
        }
    }
}
