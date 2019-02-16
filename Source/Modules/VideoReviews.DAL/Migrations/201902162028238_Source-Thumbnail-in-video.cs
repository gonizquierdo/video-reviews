namespace VideoReviews.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SourceThumbnailinvideo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Video", "Source", c => c.String());
            AddColumn("dbo.Video", "Thumbnail", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Video", "Thumbnail");
            DropColumn("dbo.Video", "Source");
        }
    }
}
