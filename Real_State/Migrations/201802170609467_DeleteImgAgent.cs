namespace Real_State.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteImgAgent : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.AgentProfiles", "ImageId", "dbo.Images");
            //DropIndex("dbo.AgentProfiles", new[] { "ImageId" });
            //DropTable("dbo.AgentProfiles");
            //DropTable("dbo.Images");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        Id = c.Byte(nullable: false, identity: true),
                        ImageName = c.String(),
                        ImagePath = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AgentProfiles",
                c => new
                    {
                        Id = c.Byte(nullable: false, identity: true),
                        Name = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        LicenseNo = c.String(),
                        PhoneNo = c.Int(nullable: false),
                        Email = c.String(),
                        Password = c.String(),
                        ImageId = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.AgentProfiles", "ImageId");
            AddForeignKey("dbo.AgentProfiles", "ImageId", "dbo.Images", "Id", cascadeDelete: true);
        }
    }
}
