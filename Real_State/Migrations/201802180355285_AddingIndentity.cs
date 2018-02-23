namespace Real_State.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingIndentity : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AgentProfiles", "ImageID", "dbo.Images");
            DropPrimaryKey("dbo.AgentProfiles");
            DropPrimaryKey("dbo.Images");
            AlterColumn("dbo.AgentProfiles", "ID", c => c.Byte(nullable: false, identity: true));
            AlterColumn("dbo.Images", "ID", c => c.Byte(nullable: false, identity: true));
            AddPrimaryKey("dbo.AgentProfiles", "ID");
            AddPrimaryKey("dbo.Images", "ID");
            AddForeignKey("dbo.AgentProfiles", "ImageID", "dbo.Images", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AgentProfiles", "ImageID", "dbo.Images");
            DropPrimaryKey("dbo.Images");
            DropPrimaryKey("dbo.AgentProfiles");
            AlterColumn("dbo.Images", "ID", c => c.Byte(nullable: false));
            AlterColumn("dbo.AgentProfiles", "ID", c => c.Byte(nullable: false));
            AddPrimaryKey("dbo.Images", "ID");
            AddPrimaryKey("dbo.AgentProfiles", "ID");
            AddForeignKey("dbo.AgentProfiles", "ImageID", "dbo.Images", "ID", cascadeDelete: true);
        }
    }
}
