using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryDatabaseAccess.Domain.Entities
{
    public class AuditoryEntity : BaseEntity
    {
        public DateTime CreationDate { get; private set; }

        internal void SetCreationAuditoryInfo()
        {
            CreationDate = DateTime.Now;
        }

        public AuditoryEntity()
        {
            SetCreationAuditoryInfo();
        }
    }
}
