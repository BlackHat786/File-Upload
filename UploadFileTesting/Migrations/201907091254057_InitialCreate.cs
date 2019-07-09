namespace UploadFileTesting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FileUploads",
                c => new
                    {
                        FileId = c.Int(nullable: false, identity: true),
                        File = c.Binary(),
                        FileName = c.String(),
                    })
                .PrimaryKey(t => t.FileId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.FileUploads");
        }
    }
}
