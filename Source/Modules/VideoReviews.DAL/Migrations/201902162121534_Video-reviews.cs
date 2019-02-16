namespace VideoReviews.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Videoreviews : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VideoReview",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        VideoID = c.Long(nullable: false),
                        Url = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Video", t => t.VideoID)
                .Index(t => t.VideoID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VideoReview", "VideoID", "dbo.Video");
            DropIndex("dbo.VideoReview", new[] { "VideoID" });
            DropTable("dbo.VideoReview");
        }
    }
}
