namespace WishList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddItemOrderfield : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Items", "Order", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Items", "Order");
        }
    }
}
