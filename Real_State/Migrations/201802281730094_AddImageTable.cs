namespace Real_State.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImageTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        ID = c.Byte(nullable: false),
                        ImageName = c.String(),
                        ImagePath = c.String(),
                        PropertyProfile_ID = c.Int(),
                        PropertyProfileId_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.PropertyProfiles", t => t.PropertyProfile_ID)
                .ForeignKey("dbo.PropertyProfiles", t => t.PropertyProfileId_ID)
                .Index(t => t.PropertyProfile_ID)
                .Index(t => t.PropertyProfileId_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Images", "PropertyProfileId_ID", "dbo.PropertyProfiles");
            DropForeignKey("dbo.Images", "PropertyProfile_ID", "dbo.PropertyProfiles");
            DropIndex("dbo.Images", new[] { "PropertyProfileId_ID" });
            DropIndex("dbo.Images", new[] { "PropertyProfile_ID" });
            DropTable("dbo.Images");
        }
    }
}
