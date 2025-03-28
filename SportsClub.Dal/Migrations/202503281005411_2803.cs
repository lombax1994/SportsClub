namespace SportsClub.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2803 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Activities",
                c => new
                    {
                        ActivityId = c.Int(nullable: false, identity: true),
                        Activityname = c.String(nullable: false, maxLength: 30),
                        MaxParticipants = c.Int(nullable: false),
                        Picture = c.String(),
                    })
                .PrimaryKey(t => t.ActivityId);
            
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        MemberId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 30),
                        LastName = c.String(nullable: false),
                        Picture = c.String(),
                    })
                .PrimaryKey(t => t.MemberId);
            
            CreateTable(
                "dbo.MemberActivities",
                c => new
                    {
                        Member_MemberId = c.Int(nullable: false),
                        Activity_ActivityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Member_MemberId, t.Activity_ActivityId })
                .ForeignKey("dbo.Members", t => t.Member_MemberId, cascadeDelete: true)
                .ForeignKey("dbo.Activities", t => t.Activity_ActivityId, cascadeDelete: true)
                .Index(t => t.Member_MemberId)
                .Index(t => t.Activity_ActivityId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MemberActivities", "Activity_ActivityId", "dbo.Activities");
            DropForeignKey("dbo.MemberActivities", "Member_MemberId", "dbo.Members");
            DropIndex("dbo.MemberActivities", new[] { "Activity_ActivityId" });
            DropIndex("dbo.MemberActivities", new[] { "Member_MemberId" });
            DropTable("dbo.MemberActivities");
            DropTable("dbo.Members");
            DropTable("dbo.Activities");
        }
    }
}
