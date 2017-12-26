namespace ServisRezervasyon.UI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Duzenleme : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Randevus", "OnaylandıMı", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Randevus", "OnaylandıMı");
        }
    }
}
