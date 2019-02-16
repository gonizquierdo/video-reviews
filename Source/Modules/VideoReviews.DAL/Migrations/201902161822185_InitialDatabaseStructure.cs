namespace VideoReviews.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDatabaseStructure : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Username = c.String(),
                        Email = c.String(),
                        TwitchAccessToken = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Video",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        TenantID = c.Long(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.TenantID)
                .Index(t => t.TenantID);
            
            CreateTable(
                "dbo.VideoComment",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        VideoID = c.Long(nullable: false),
                        Content = c.String(),
                        TenantID = c.Long(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.TenantID)
                .ForeignKey("dbo.Video", t => t.VideoID)
                .Index(t => t.VideoID)
                .Index(t => t.TenantID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Video", "TenantID", "dbo.User");
            DropForeignKey("dbo.VideoComment", "VideoID", "dbo.Video");
            DropForeignKey("dbo.VideoComment", "TenantID", "dbo.User");
            DropIndex("dbo.VideoComment", new[] { "TenantID" });
            DropIndex("dbo.VideoComment", new[] { "VideoID" });
            DropIndex("dbo.Video", new[] { "TenantID" });
            DropTable("dbo.VideoComment");
            DropTable("dbo.Video");
            DropTable("dbo.User");
        }
    }
}
