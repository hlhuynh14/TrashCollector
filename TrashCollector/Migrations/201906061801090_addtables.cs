namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtables : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "oneTimePickUp", c => c.DateTime());
            AlterColumn("dbo.Customers", "suspendedStart", c => c.DateTime());
            AlterColumn("dbo.Customers", "supspendEnd", c => c.DateTime());
            DropTable("dbo.Roles");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserType = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AlterColumn("dbo.Customers", "supspendEnd", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Customers", "suspendedStart", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Customers", "oneTimePickUp", c => c.DateTime(nullable: false));
        }
    }
}
