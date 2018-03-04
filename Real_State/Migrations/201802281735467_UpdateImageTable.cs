namespace Real_State.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateImageTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Images", "PropertyProfileId_ID", "dbo.PropertyProfiles");
            DropForeignKey("dbo.Images", "PropertyProfile_ID", "dbo.PropertyProfiles");
            DropIndex("dbo.Images", new[] { "PropertyProfile_ID" });
            DropIndex("dbo.Images", new[] { "PropertyProfileId_ID" });
            RenameColumn(table: "dbo.Images", name: "PropertyProfile_ID", newName: "PropertyProfileID");
            AlterColumn("dbo.Images", "PropertyProfileID", c => c.Int(nullable: false));
            CreateIndex("dbo.Images", "PropertyProfileID");
            AddForeignKey("dbo.Images", "PropertyProfileID", "dbo.PropertyProfiles", "ID", cascadeDelete: true);
            DropColumn("dbo.Images", "PropertyProfileId_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Images", "PropertyProfileId_ID", c => c.Int());
            DropForeignKey("dbo.Images", "PropertyProfileID", "dbo.PropertyProfiles");
            DropIndex("dbo.Images", new[] { "PropertyProfileID" });
            AlterColumn("dbo.Images", "PropertyProfileID", c => c.Int());
            RenameColumn(table: "dbo.Images", name: "PropertyProfileID", newName: "PropertyProfile_ID");
            CreateIndex("dbo.Images", "PropertyProfileId_ID");
            CreateIndex("dbo.Images", "PropertyProfile_ID");
            AddForeignKey("dbo.Images", "PropertyProfile_ID", "dbo.PropertyProfiles", "ID");
            AddForeignKey("dbo.Images", "PropertyProfileId_ID", "dbo.PropertyProfiles", "ID");
        }
    }
}
