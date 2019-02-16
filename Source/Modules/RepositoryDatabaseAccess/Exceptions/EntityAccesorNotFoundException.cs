using RepositoryDatabaseAccess.Context;
using RepositoryDatabaseAccess.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryDatabaseAccess.Exceptions
{
    public class EntityAccesorNotFoundException<TEntity> : DatabaseAccessException 
        where TEntity : BaseEntity 
    {
        public EntityAccesorNotFoundException() : base($"Accesor for type {typeof(TEntity).Name} was not found. Make sure that you defined an accesor on your DbContext")
        {

        }
    }
}
