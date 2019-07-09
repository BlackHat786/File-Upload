namespace UploadFileTesting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ix : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.FileUploads", "File", c => c.Binary(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.FileUploads", "File", c => c.Binary());
        }
    }
}
