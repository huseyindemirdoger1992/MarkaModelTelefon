namespace MarkaModelTelefon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DbV3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MyTelefons", "GarantiDurumu", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MyTelefons", "GarantiDurumu");
        }
    }
}
