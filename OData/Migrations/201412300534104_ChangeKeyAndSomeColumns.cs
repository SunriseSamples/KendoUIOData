namespace OData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeKeyAndSomeColumns : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Products");
            AddColumn("dbo.Products", "Currency", c => c.String());
            AddColumn("dbo.Products", "UnitPrice", c => c.Decimal(precision: 18, scale: 4));
            AddColumn("dbo.Products", "CategoryID", c => c.Int());
            AddColumn("dbo.Products", "Memo", c => c.String());
            DropColumn("dbo.Products", "Id");
            AddColumn("dbo.Products", "ID", c => c.Guid(nullable: false, identity: true));
            AddPrimaryKey("dbo.Products", "ID");
            DropColumn("dbo.Products", "Price");
            DropColumn("dbo.Products", "Category");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Category", c => c.String());
            AddColumn("dbo.Products", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropPrimaryKey("dbo.Products");
            DropColumn("dbo.Products", "ID");
            AddColumn("dbo.Products", "Id", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Products", "Memo");
            DropColumn("dbo.Products", "CategoryID");
            DropColumn("dbo.Products", "UnitPrice");
            DropColumn("dbo.Products", "Currency");
            AddPrimaryKey("dbo.Products", "Id");
        }
    }
}
