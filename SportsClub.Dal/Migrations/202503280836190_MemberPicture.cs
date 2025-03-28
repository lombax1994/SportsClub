namespace SportsClub.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MemberPicture : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Members", "Picture", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Members", "Picture");
        }
    }
}
