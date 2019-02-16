using RepositoryDatabaseAccess.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoReviews.DAL.Domain.Entities
{
    public class VideoReview : AuditoryEntity
    {
        public long VideoID { get; set; }

        [ForeignKey("VideoID")]
        public Video Video { get; set; }

        public string Url { get; set; }
    }
}
