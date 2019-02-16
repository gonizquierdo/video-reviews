using RepositoryDatabaseAccess.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryDatabaseAccess.Exceptions
{
    public class TenantEntityWithoutTenantException<TEntity, TTenantEntity> : DatabaseAccessException
        where TEntity : TenantAuditoryEntity<TTenantEntity>
        where TTenantEntity : BaseEntity
    {
        public TenantEntityWithoutTenantException() : base($"Entity of type {typeof(TEntity).Name }must have a TenantID or a Tenant of type {typeof(TTenantEntity).Name} assigned")
        {
        }
    }

}
