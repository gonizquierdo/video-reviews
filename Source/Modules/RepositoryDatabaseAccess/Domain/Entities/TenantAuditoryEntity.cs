using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryDatabaseAccess.Domain.Entities
{
    public class TenantAuditoryEntity<T> : AuditoryEntity where T : BaseEntity
    {
        public long TenantID { get; set; }

        [ForeignKey("TenantID")]
        public T Tenant { get; set; }
    }
}
