namespace OData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Spatial;
    
    public partial class AddDatabaseColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Description", c => c.String(maxLength: 1024));
            AddColumn("dbo.Products", "IntroductionUrl", c => c.String(maxLength: 2048));
            AddColumn("dbo.Products", "ImageUrl", c => c.String(maxLength: 2048));
            AddColumn("dbo.Products", "Bit", c => c.Boolean());
            AddColumn("dbo.Products", "TinyInt", c => c.Byte());
            AddColumn("dbo.Products", "SmallInt", c => c.Short());
            AddColumn("dbo.Products", "Int", c => c.Int());
            AddColumn("dbo.Products", "BigInt", c => c.Long());
            AddColumn("dbo.Products", "SmallMoney", c => c.Decimal(storeType: "smallmoney"));
            AddColumn("dbo.Products", "Money", c => c.Decimal(storeType: "money"));
            AddColumn("dbo.Products", "Decimal", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.Products", "Numeric", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.Products", "Numeric5", c => c.Decimal(precision: 9, scale: 2));
            AddColumn("dbo.Products", "Numeric9", c => c.Decimal(precision: 19, scale: 2));
            AddColumn("dbo.Products", "Numeric13", c => c.Decimal(precision: 28, scale: 2));
            AddColumn("dbo.Products", "Numeric17", c => c.Decimal(precision: 38, scale: 2));
            AddColumn("dbo.Products", "Real", c => c.Single());
            AddColumn("dbo.Products", "Float", c => c.Double());
            AddColumn("dbo.Products", "Date", c => c.DateTime(storeType: "date"));
            AddColumn("dbo.Products", "Time", c => c.Time(precision: 7));
            AddColumn("dbo.Products", "SmallDateTime", c => c.DateTime(storeType: "smalldatetime"));
            AddColumn("dbo.Products", "DateTime", c => c.DateTime());
            AddColumn("dbo.Products", "DateTime2", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AddColumn("dbo.Products", "DateTimeOffset", c => c.DateTimeOffset(precision: 7));
            AddColumn("dbo.Products", "Char10", c => c.String(maxLength: 10, fixedLength: true, unicode: false));
            AddColumn("dbo.Products", "VarChar50", c => c.String(maxLength: 50, unicode: false));
            AddColumn("dbo.Products", "VarCharMax", c => c.String(unicode: false));
            AddColumn("dbo.Products", "Text", c => c.String(unicode: false, storeType: "text"));
            AddColumn("dbo.Products", "NChar10", c => c.String(maxLength: 10, fixedLength: true));
            AddColumn("dbo.Products", "NVarChar50", c => c.String(maxLength: 50));
            AddColumn("dbo.Products", "NVarCharMax", c => c.String());
            AddColumn("dbo.Products", "NText", c => c.String(storeType: "ntext"));
            AddColumn("dbo.Products", "Binary", c => c.Binary(maxLength: 50, fixedLength: true));
            AddColumn("dbo.Products", "VarBinary", c => c.Binary(maxLength: 50));
            AddColumn("dbo.Products", "VarBinaryMax", c => c.Binary());
            AddColumn("dbo.Products", "Image", c => c.Binary(storeType: "image"));
            AddColumn("dbo.Products", "RowVersion", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.Products", "Xml", c => c.String(storeType: "xml"));
            AddColumn("dbo.Products", "Geometry", c => c.Geometry());
            AddColumn("dbo.Products", "Geography", c => c.Geography());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Geography");
            DropColumn("dbo.Products", "Geometry");
            DropColumn("dbo.Products", "Xml");
            DropColumn("dbo.Products", "RowVersion");
            DropColumn("dbo.Products", "Image");
            DropColumn("dbo.Products", "VarBinaryMax");
            DropColumn("dbo.Products", "VarBinary");
            DropColumn("dbo.Products", "Binary");
            DropColumn("dbo.Products", "NText");
            DropColumn("dbo.Products", "NVarCharMax");
            DropColumn("dbo.Products", "NVarChar50");
            DropColumn("dbo.Products", "NChar10");
            DropColumn("dbo.Products", "Text");
            DropColumn("dbo.Products", "VarCharMax");
            DropColumn("dbo.Products", "VarChar50");
            DropColumn("dbo.Products", "Char10");
            DropColumn("dbo.Products", "DateTimeOffset");
            DropColumn("dbo.Products", "DateTime2");
            DropColumn("dbo.Products", "DateTime");
            DropColumn("dbo.Products", "SmallDateTime");
            DropColumn("dbo.Products", "Time");
            DropColumn("dbo.Products", "Date");
            DropColumn("dbo.Products", "Float");
            DropColumn("dbo.Products", "Real");
            DropColumn("dbo.Products", "Numeric17");
            DropColumn("dbo.Products", "Numeric13");
            DropColumn("dbo.Products", "Numeric9");
            DropColumn("dbo.Products", "Numeric5");
            DropColumn("dbo.Products", "Numeric");
            DropColumn("dbo.Products", "Decimal");
            DropColumn("dbo.Products", "Money");
            DropColumn("dbo.Products", "SmallMoney");
            DropColumn("dbo.Products", "BigInt");
            DropColumn("dbo.Products", "Int");
            DropColumn("dbo.Products", "SmallInt");
            DropColumn("dbo.Products", "TinyInt");
            DropColumn("dbo.Products", "Bit");
            DropColumn("dbo.Products", "ImageUrl");
            DropColumn("dbo.Products", "IntroductionUrl");
            DropColumn("dbo.Products", "Description");
        }
    }
}
