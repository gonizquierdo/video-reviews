using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryDatabaseAccess.Exceptions
{
    public abstract class DatabaseAccessException : Exception
    {
        public DatabaseAccessException(string message) : base(message)
        {

        }
    }
}
