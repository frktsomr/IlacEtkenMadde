namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEntity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contents", "HeadingID", c => c.Int());
            CreateIndex("dbo.Contents", "HeadingID");
            AddForeignKey("dbo.Contents", "HeadingID", "dbo.Headings", "HeadingID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contents", "HeadingID", "dbo.Headings");
            DropIndex("dbo.Contents", new[] { "HeadingID" });
            DropColumn("dbo.Contents", "HeadingID");
        }
    }
}
