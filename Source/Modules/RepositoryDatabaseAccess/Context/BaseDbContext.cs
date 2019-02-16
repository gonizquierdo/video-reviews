using RepositoryDatabaseAccess.Domain.Entities;
using RepositoryDatabaseAccess.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace RepositoryDatabaseAccess.Context
{
    public abstract class BaseDbContext<TDbContext> : DbContext
    {
        public BaseDbContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {
            
        }

        public BaseDbContext() : this(ConfigurationManager.AppSettings["RepositoryDatabaseAccessEntities"])
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

        internal Func<TDbContext, DbSet<TEntity>> GetEntitiesAccesor<TEntity>() where TEntity : BaseEntity
        {
            var property = typeof(TDbContext).GetProperties()
                .FirstOrDefault(x => x.PropertyType.Equals(typeof(DbSet<TEntity>)));
            if (property == null)
            {
                throw new EntityAccesorNotFoundException<TEntity>();
            }

            var method = property.GetGetMethod();

            ParameterExpression paramExpression = Expression.Parameter(this.GetType(), "value");

            Expression propertyGetterExpression = Expression.Property(paramExpression, property.Name);

            var result = Expression.Lambda<Func<TDbContext, DbSet<TEntity>>>(propertyGetterExpression, paramExpression).Compile();
            return result;
        }
    }
}
