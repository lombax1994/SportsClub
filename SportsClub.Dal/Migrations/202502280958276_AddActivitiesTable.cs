namespace SportsClub.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddActivitiesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Activities",
                c => new
                    {
                        ActivityId = c.Int(nullable: false, identity: true),
                        Activityname = c.String(),
                        MaxParticipants = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ActivityId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Activities");
        }
    }
}
