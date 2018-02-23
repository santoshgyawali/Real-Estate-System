namespace Real_State.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteTables : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AgentProfiles", "ImageID", "dbo.Images");
            DropIndex("dbo.AgentProfiles", new[] { "ImageID" });
            DropTable("dbo.AgentProfiles");
            DropTable("dbo.Images");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        ID = c.Byte(nullable: false),
                        ImageName = c.String(),
                        ImagePath = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.AgentProfiles",
                c => new
                    {
                        ID = c.Byte(nullable: false),
                        Name = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        LicenseNo = c.String(),
                        PhoneNo = c.Int(nullable: false),
                        Email = c.String(),
                        Password = c.String(),
                        ImageID = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateIndex("dbo.AgentProfiles", "ImageID");
            AddForeignKey("dbo.AgentProfiles", "ImageID", "dbo.Images", "ID", cascadeDelete: true);
        }
    }
}
