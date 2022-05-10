namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deneme2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Contents", "UserID", "dbo.Users");
            DropIndex("dbo.Contents", new[] { "UserID" });
            AddColumn("dbo.Contents", "ContentValue", c => c.String(maxLength: 1500));
            AlterColumn("dbo.Contents", "UserID", c => c.Int());
            CreateIndex("dbo.Contents", "UserID");
            AddForeignKey("dbo.Contents", "UserID", "dbo.Users", "UserID");
            DropColumn("dbo.Contents", "ContentName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contents", "ContentName", c => c.String(maxLength: 500));
            DropForeignKey("dbo.Contents", "UserID", "dbo.Users");
            DropIndex("dbo.Contents", new[] { "UserID" });
            AlterColumn("dbo.Contents", "UserID", c => c.Int(nullable: false));
            DropColumn("dbo.Contents", "ContentValue");
            CreateIndex("dbo.Contents", "UserID");
            AddForeignKey("dbo.Contents", "UserID", "dbo.Users", "UserID", cascadeDelete: true);
        }
    }
}
