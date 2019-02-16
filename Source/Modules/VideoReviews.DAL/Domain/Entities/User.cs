using RepositoryDatabaseAccess.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoReviews.DAL.Domain.Entities
{
    public class User : AuditoryEntity
    {
        public string Username { get; set; }

        public string Email { get; set; }

        public string TwitchAccessToken { get; set; }

        public List<Video> Videos { get; set; }
    }
}
