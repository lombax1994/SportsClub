namespace SportsClub.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Activities", "Activityname", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Members", "FirstName", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Members", "LastName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Members", "LastName", c => c.String());
            AlterColumn("dbo.Members", "FirstName", c => c.String());
            AlterColumn("dbo.Activities", "Activityname", c => c.String());
        }
    }
}
