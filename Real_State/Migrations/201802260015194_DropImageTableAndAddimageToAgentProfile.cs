namespace Real_State.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropImageTableAndAddimageToAgentProfile : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AgentProfiles", "ImageID", "dbo.Images");
            DropIndex("dbo.AgentProfiles", new[] { "ImageID" });
            AddColumn("dbo.AgentProfiles", "ImageName", c => c.String());
            AddColumn("dbo.AgentProfiles", "ImagePath", c => c.String());
            DropColumn("dbo.AgentProfiles", "ImageID");
            DropTable("dbo.Images");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        ID = c.Byte(nullable: false, identity: true),
                        ImageName = c.String(),
                        ImagePath = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.AgentProfiles", "ImageID", c => c.Byte(nullable: false));
            DropColumn("dbo.AgentProfiles", "ImagePath");
            DropColumn("dbo.AgentProfiles", "ImageName");
            CreateIndex("dbo.AgentProfiles", "ImageID");
            AddForeignKey("dbo.AgentProfiles", "ImageID", "dbo.Images", "ID", cascadeDelete: true);
        }
    }
}
