namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "ContactSubject", c => c.String(maxLength: 500));
            AddColumn("dbo.Contacts", "UserMail", c => c.String());
            DropColumn("dbo.Contacts", "ContactHeading");
            DropColumn("dbo.Contacts", "ContactDegree");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contacts", "ContactDegree", c => c.String(maxLength: 500));
            AddColumn("dbo.Contacts", "ContactHeading", c => c.String(maxLength: 500));
            DropColumn("dbo.Contacts", "UserMail");
            DropColumn("dbo.Contacts", "ContactSubject");
        }
    }
}
