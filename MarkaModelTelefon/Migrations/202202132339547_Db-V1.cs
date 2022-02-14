namespace MarkaModelTelefon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DbV1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MyMarkas",
                c => new
                    {
                        MarkaId = c.Int(nullable: false, identity: true),
                        MarkaAd = c.String(),
                    })
                .PrimaryKey(t => t.MarkaId);
            
            CreateTable(
                "dbo.MyModels",
                c => new
                    {
                        ModelId = c.Int(nullable: false, identity: true),
                        ModelAd = c.String(),
                        MarkaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ModelId)
                .ForeignKey("dbo.MyMarkas", t => t.MarkaId, cascadeDelete: true)
                .Index(t => t.MarkaId);
            
            CreateTable(
                "dbo.MyTelefons",
                c => new
                    {
                        TelefonId = c.Int(nullable: false, identity: true),
                        RenkId = c.Int(nullable: false),
                        TelefonGRM = c.Double(nullable: false),
                        TelefonMA = c.Int(nullable: false),
                        TelefonOnKameraPX = c.Int(nullable: false),
                        TelefonOnArkaKameraPX = c.Int(nullable: false),
                        Adet = c.Int(nullable: false),
                        ModelId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TelefonId)
                .ForeignKey("dbo.MyModels", t => t.ModelId, cascadeDelete: true)
                .ForeignKey("dbo.Renks", t => t.RenkId, cascadeDelete: true)
                .Index(t => t.RenkId)
                .Index(t => t.ModelId);
            
            CreateTable(
                "dbo.Renks",
                c => new
                    {
                        RenkId = c.Int(nullable: false, identity: true),
                        RenkAd = c.String(),
                    })
                .PrimaryKey(t => t.RenkId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MyTelefons", "RenkId", "dbo.Renks");
            DropForeignKey("dbo.MyTelefons", "ModelId", "dbo.MyModels");
            DropForeignKey("dbo.MyModels", "MarkaId", "dbo.MyMarkas");
            DropIndex("dbo.MyTelefons", new[] { "ModelId" });
            DropIndex("dbo.MyTelefons", new[] { "RenkId" });
            DropIndex("dbo.MyModels", new[] { "MarkaId" });
            DropTable("dbo.Renks");
            DropTable("dbo.MyTelefons");
            DropTable("dbo.MyModels");
            DropTable("dbo.MyMarkas");
        }
    }
}
