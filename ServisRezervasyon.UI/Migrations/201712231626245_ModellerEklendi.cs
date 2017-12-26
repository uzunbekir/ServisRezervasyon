namespace ServisRezervasyon.UI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModellerEklendi : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Aracs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Plaka = c.String(),
                        Marka = c.String(nullable: false),
                        Model = c.String(nullable: false),
                        ModelYili = c.DateTime(nullable: false),
                        Aciklama = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Randevus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tarih = c.DateTime(),
                        AracId = c.Int(nullable: false),
                        MusteriId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Aracs", t => t.AracId, cascadeDelete: true)
                .ForeignKey("dbo.Musteris", t => t.MusteriId, cascadeDelete: true)
                .Index(t => t.AracId)
                .Index(t => t.MusteriId);
            
            CreateTable(
                "dbo.Musteris",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ad = c.String(nullable: false),
                        Soyad = c.String(nullable: false),
                        Telefon = c.String(nullable: false),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Randevus", "MusteriId", "dbo.Musteris");
            DropForeignKey("dbo.Randevus", "AracId", "dbo.Aracs");
            DropIndex("dbo.Randevus", new[] { "MusteriId" });
            DropIndex("dbo.Randevus", new[] { "AracId" });
            DropTable("dbo.Musteris");
            DropTable("dbo.Randevus");
            DropTable("dbo.Aracs");
        }
    }
}
