namespace ServisRezervasyon.UI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deneme : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Randevus", "AracId", "dbo.Aracs");
            DropForeignKey("dbo.Randevus", "MusteriId", "dbo.Musteris");
            DropIndex("dbo.Randevus", new[] { "AracId" });
            DropIndex("dbo.Randevus", new[] { "MusteriId" });
            AlterColumn("dbo.Randevus", "AracId", c => c.Int());
            AlterColumn("dbo.Randevus", "MusteriId", c => c.Int());
            CreateIndex("dbo.Randevus", "AracId");
            CreateIndex("dbo.Randevus", "MusteriId");
            AddForeignKey("dbo.Randevus", "AracId", "dbo.Aracs", "Id");
            AddForeignKey("dbo.Randevus", "MusteriId", "dbo.Musteris", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Randevus", "MusteriId", "dbo.Musteris");
            DropForeignKey("dbo.Randevus", "AracId", "dbo.Aracs");
            DropIndex("dbo.Randevus", new[] { "MusteriId" });
            DropIndex("dbo.Randevus", new[] { "AracId" });
            AlterColumn("dbo.Randevus", "MusteriId", c => c.Int(nullable: false));
            AlterColumn("dbo.Randevus", "AracId", c => c.Int(nullable: false));
            CreateIndex("dbo.Randevus", "MusteriId");
            CreateIndex("dbo.Randevus", "AracId");
            AddForeignKey("dbo.Randevus", "MusteriId", "dbo.Musteris", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Randevus", "AracId", "dbo.Aracs", "Id", cascadeDelete: true);
        }
    }
}
