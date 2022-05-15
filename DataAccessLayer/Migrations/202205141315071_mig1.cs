namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "ContactDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Admins", "AdminUserName", c => c.String(maxLength: 50));
            AddColumn("dbo.Admins", "AdminRole", c => c.String(maxLength: 1));
            AlterColumn("dbo.Admins", "AdminPassword", c => c.String(maxLength: 50));
            DropColumn("dbo.Admins", "AdminName");
            DropColumn("dbo.Admins", "AdminSurname");
            DropColumn("dbo.Admins", "AdminMail");
            DropColumn("dbo.Admins", "AdminPhoto");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Admins", "AdminPhoto", c => c.String(maxLength: 500));
            AddColumn("dbo.Admins", "AdminMail", c => c.String(maxLength: 100));
            AddColumn("dbo.Admins", "AdminSurname", c => c.String(maxLength: 50));
            AddColumn("dbo.Admins", "AdminName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Admins", "AdminPassword", c => c.String(maxLength: 100));
            DropColumn("dbo.Admins", "AdminRole");
            DropColumn("dbo.Admins", "AdminUserName");
            DropColumn("dbo.Contacts", "ContactDate");
        }
    }
}
