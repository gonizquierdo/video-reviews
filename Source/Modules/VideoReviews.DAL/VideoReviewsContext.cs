using RepositoryDatabaseAccess.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoReviews.DAL.Domain.Entities;

namespace VideoReviews.DAL
{
    public class VideoReviewsContext : BaseDbContext<VideoReviewsContext>
    {
        public VideoReviewsContext() : base("DefaultConnection")
        {

        }

        public DbSet<User> User { get; set; }
        public DbSet<Video> Video { get; set; }
        public DbSet<VideoComment> VideoComment { get; set; }
        public DbSet<VideoReview> VideoReview { get; set; }
    }
}
