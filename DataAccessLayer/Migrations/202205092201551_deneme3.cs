namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deneme3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Contents", "UserID", "dbo.Users");
            DropIndex("dbo.Contents", new[] { "UserID" });
            AlterColumn("dbo.Contents", "UserID", c => c.Int(nullable: false));
            CreateIndex("dbo.Contents", "UserID");
            AddForeignKey("dbo.Contents", "UserID", "dbo.Users", "UserID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contents", "UserID", "dbo.Users");
            DropIndex("dbo.Contents", new[] { "UserID" });
            AlterColumn("dbo.Contents", "UserID", c => c.Int());
            CreateIndex("dbo.Contents", "UserID");
            AddForeignKey("dbo.Contents", "UserID", "dbo.Users", "UserID");
        }
    }
}
