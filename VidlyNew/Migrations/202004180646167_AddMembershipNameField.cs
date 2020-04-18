namespace VidlyNew.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMembershipNameField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MembershipTypes", "MembershipName", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MembershipTypes", "MembershipName");
        }
    }
}
