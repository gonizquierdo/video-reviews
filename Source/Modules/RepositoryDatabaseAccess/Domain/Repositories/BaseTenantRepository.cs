using RepositoryDatabaseAccess.Context;
using RepositoryDatabaseAccess.Domain.Entities;
using RepositoryDatabaseAccess.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryDatabaseAccess.Domain.Repositories
{
    public class BaseTenantRepository<TDbContext, TEntity, TTenantEntity> : BaseRepository<TDbContext, TEntity>
        where TDbContext : BaseDbContext<TDbContext>
        where TEntity : TenantAuditoryEntity<TTenantEntity>
        where TTenantEntity : BaseEntity
    {

        protected long TenantID { get; set; }

        public BaseTenantRepository(TDbContext dbContext, long tenantId) : base(dbContext)
        {
            TenantID = tenantId;
        }

        protected override IQueryable<TEntity> Entities => base.Entities.Where(x => x.TenantID == TenantID);

        public override void Add(TEntity entity)
        {
            entity.TenantID = TenantID;
            if (entity.TenantID == 0 && entity.Tenant == null)
            {
                throw new TenantEntityWithoutTenantException<TEntity, TTenantEntity>();
            }
            base.Add(entity);
        }
    }
}
