namespace OData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMoney : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "CurrencyID", "dbo.Currencies");
            DropIndex("dbo.Currencies", new[] { "Code" });
            DropIndex("dbo.Products", new[] { "CurrencyID" });
            DropTable("dbo.Currencies");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Currencies",
                c => new
                    {
                        ID = c.Short(nullable: false),
                        Code = c.String(nullable: false, maxLength: 3, fixedLength: true, unicode: false),
                        Culture = c.String(maxLength: 5, fixedLength: true, unicode: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateIndex("dbo.Products", "CurrencyID");
            CreateIndex("dbo.Currencies", "Code", unique: true);
            AddForeignKey("dbo.Products", "CurrencyID", "dbo.Currencies", "ID");
        }
    }
}
