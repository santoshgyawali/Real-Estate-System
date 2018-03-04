namespace Real_State.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeIntToByteInID : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Images", "PropertyProfileID", "dbo.PropertyProfiles");
            DropIndex("dbo.Images", new[] { "PropertyProfileID" });
            DropPrimaryKey("dbo.PropertyProfiles");
            AddColumn("dbo.Images", "PropertyProfile_ID", c => c.Byte());
            AlterColumn("dbo.PropertyProfiles", "ID", c => c.Byte(nullable: false));
            AddPrimaryKey("dbo.PropertyProfiles", "ID");
            CreateIndex("dbo.Images", "PropertyProfile_ID");
            AddForeignKey("dbo.Images", "PropertyProfile_ID", "dbo.PropertyProfiles", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Images", "PropertyProfile_ID", "dbo.PropertyProfiles");
            DropIndex("dbo.Images", new[] { "PropertyProfile_ID" });
            DropPrimaryKey("dbo.PropertyProfiles");
            AlterColumn("dbo.PropertyProfiles", "ID", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Images", "PropertyProfile_ID");
            AddPrimaryKey("dbo.PropertyProfiles", "ID");
            CreateIndex("dbo.Images", "PropertyProfileID");
            AddForeignKey("dbo.Images", "PropertyProfileID", "dbo.PropertyProfiles", "ID", cascadeDelete: true);
        }
    }
}
