namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_addUserActive : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "UserActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "UserActive");
        }
    }
}
