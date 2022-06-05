namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Medicines", "CategoryID", "dbo.Categories");
            DropIndex("dbo.Medicines", new[] { "CategoryID" });
            DropColumn("dbo.Medicines", "CategoryID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Medicines", "CategoryID", c => c.Int(nullable: false));
            CreateIndex("dbo.Medicines", "CategoryID");
            AddForeignKey("dbo.Medicines", "CategoryID", "dbo.Categories", "CategoryID", cascadeDelete: true);
        }
    }
}
