using RepositoryDatabaseAccess.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoReviews.DAL.Domain.Entities
{
    public class Video : TenantAuditoryEntity<User>
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Source { get; set; }

        public string Thumbnail { get; set; }

        public List<VideoComment> Comments { get; set; }
    }
}
