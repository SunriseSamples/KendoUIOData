namespace OData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCurrencyAndCategory : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Products");
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Currencies",
                c => new
                    {
                        ID = c.Short(nullable: false),
                        Code = c.String(nullable: false, maxLength: 3, fixedLength: true, unicode: false),
                        Culture = c.String(maxLength: 5, fixedLength: true, unicode: false),
                    })
                .PrimaryKey(t => t.ID)
                .Index(t => t.Code, unique: true);
            
            AddColumn("dbo.Products", "CurrencyID", c => c.Short());
            AlterColumn("dbo.Products", "ID", c => c.Guid(nullable: false, identity: true));
            AlterColumn("dbo.Products", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Products", "UnitPrice", c => c.Decimal(storeType: "money"));
            AlterColumn("dbo.Products", "CategoryID", c => c.Int());
            AddPrimaryKey("dbo.Products", "ID");
            CreateIndex("dbo.Products", "CurrencyID");
            CreateIndex("dbo.Products", "CategoryID");
            AddForeignKey("dbo.Products", "CategoryID", "dbo.Categories", "ID");
            AddForeignKey("dbo.Products", "CurrencyID", "dbo.Currencies", "ID");
            DropColumn("dbo.Products", "Currency");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Currency", c => c.String());
            DropForeignKey("dbo.Products", "CurrencyID", "dbo.Currencies");
            DropForeignKey("dbo.Products", "CategoryID", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "CategoryID" });
            DropIndex("dbo.Products", new[] { "CurrencyID" });
            DropIndex("dbo.Currencies", new[] { "Code" });
            DropPrimaryKey("dbo.Products");
            AlterColumn("dbo.Products", "CategoryID", c => c.Long());
            AlterColumn("dbo.Products", "UnitPrice", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Products", "Name", c => c.String());
            AlterColumn("dbo.Products", "ID", c => c.Guid(nullable: false));
            DropColumn("dbo.Products", "CurrencyID");
            DropTable("dbo.Currencies");
            DropTable("dbo.Categories");
            AddPrimaryKey("dbo.Products", "ID");
        }
    }
}
