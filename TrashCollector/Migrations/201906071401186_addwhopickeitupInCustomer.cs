namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addwhopickeitupInCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "whoPickedItUp", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "whoPickedItUp");
        }
    }
}
