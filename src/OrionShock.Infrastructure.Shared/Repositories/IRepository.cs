using OrionShock.Infrastructure.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrionShock.Infrastructure.Shared.Repositories
{
    /// <summary>
    /// Defines a contract that describes a repository.
    /// </summary>
    /// <typeparam name="T">The type of entity this repository manages.</typeparam>
    public interface IRepository<T> where T : EntityBase
    {
        void Add(T entity);

        T Get(int id);

        void Update(T entity);

        void Delete(T entity);
    }
}
