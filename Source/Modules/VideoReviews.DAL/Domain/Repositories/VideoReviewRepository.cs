using RepositoryDatabaseAccess.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoReviews.DAL.Domain.Entities;

namespace VideoReviews.DAL.Domain.Repositories
{
    public class VideoReviewRepository : BaseRepository<VideoReviewsContext, VideoReview>
    {
        public VideoReviewRepository(VideoReviewsContext dbContext) : base(dbContext)
        {
        }
    }
}
