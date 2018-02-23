namespace Real_State.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImageAgentTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AgentProfiles",
                c => new
                    {
                        ID = c.Byte(nullable: false, identity: true),
                        Name = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        LicenseNo = c.String(),
                        PhoneNo = c.Int(nullable: false),
                        Email = c.String(),
                        Password = c.String(),
                        ImageID = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Images", t => t.ImageID, cascadeDelete: true)
                .Index(t => t.ImageID);
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        ID = c.Byte(nullable: false, identity: true),
                        ImageName = c.String(),
                        ImagePath = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AgentProfiles", "ImageID", "dbo.Images");
            DropIndex("dbo.AgentProfiles", new[] { "ImageID" });
            DropTable("dbo.Images");
            DropTable("dbo.AgentProfiles");
        }
    }
}
