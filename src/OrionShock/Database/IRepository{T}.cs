using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Orion.Core;

namespace OrionShock.Database {
    /// <summary>
    /// Describes a repository.
    /// </summary>
    /// <typeparam name="T">The type of objects this repository works with.</typeparam>
    [Service(ServiceScope.Transient)]
    public interface IRepository<T>
        where T : class {
        /// <summary>
        /// Inserts a given object into the database.
        /// </summary>
        /// <param name="obj">The object.</param>
        void Create([NotNull] T obj);

        /// <summary>
        /// Reads a given object from the database.
        /// </summary>
        /// <returns>The read object.</returns>
        T Read();

        /// <summary>
        /// Updates the given object.
        /// </summary>
        /// <param name="obj">The object.</param>
        void Update([NotNull] T obj);

        /// <summary>
        /// Deletes the given object.
        /// </summary>
        /// <param name="obj">The object.</param>
        void Delete(T obj);
    }
}