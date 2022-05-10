namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_imagesizechange1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "UserPhoto", c => c.String(maxLength: 500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "UserPhoto", c => c.String(maxLength: 250));
        }
    }
}
