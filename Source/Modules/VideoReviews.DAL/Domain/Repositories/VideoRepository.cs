using RepositoryDatabaseAccess.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoReviews.DAL.Domain.Entities;

namespace VideoReviews.DAL.Domain.Repositories
{
    public class VideoRepository : BaseTenantRepository<VideoReviewsContext, Video, User>
    {
        public VideoRepository(VideoReviewsContext dbContext, long userId) : base(dbContext, userId)
        {
        }
    }
}
