using RepositoryDatabaseAccess.Context;
using RepositoryDatabaseAccess.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryDatabaseAccess.Domain.Repositories
{
    /// <summary>
    /// Base repository for all interactions with database
    /// </summary>
    /// <typeparam name="TDbContext">Your DbContext type</typeparam>
    /// <typeparam name="TEntity">Your entity type. You must declare a DbSet<typeparamref name="TEntity"/> on TDbContext.</typeparam>
    public class BaseRepository<TDbContext, TEntity> 
        where TEntity : BaseEntity
        where TDbContext : BaseDbContext<TDbContext>
    {
        protected TDbContext DbContext;

        private Func<TDbContext, DbSet<TEntity>> EntitiesAccesor;

        private DbSet<TEntity> _Entities
        {
            get
            {
                return EntitiesAccesor.Invoke(DbContext);
            }
        }

        protected virtual IQueryable<TEntity> Entities
        {
            get
            {
                return _Entities.AsQueryable();
            }
        }

        public BaseRepository(TDbContext dbContext)
        {
            DbContext = dbContext;
            EntitiesAccesor = DbContext.GetEntitiesAccesor<TEntity>();
        }

        /// <summary>
        /// List all entities
        /// </summary>
        /// <returns></returns>
        public virtual IList<TEntity> List()
        {
            return Entities.ToList();
        }

        /// <summary>
        /// Get entity by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual TEntity Get(long id)
        {
            return Entities.FirstOrDefault(x => x.Id.Equals(id));
        }

        /// <summary>
        /// Adds entity to context
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Add(TEntity entity)
        {
            if (entity is AuditoryEntity)
            {
                AuditoryEntity auditoryEntity = entity as AuditoryEntity;
                auditoryEntity.SetCreationAuditoryInfo();
            }
            _Entities.Add(entity);
        }

        /// <summary>
        /// Remove entity from context
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(TEntity entity)
        {
            _Entities.Remove(entity);
        }

        /// <summary>
        /// Persist changes on database
        /// </summary>
        public void PersistChanges()
        {
            DbContext.SaveChanges();
        }
    }
}
