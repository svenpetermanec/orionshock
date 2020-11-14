using System;
using JetBrains.Annotations;

namespace OrionShock.Database {
    /// <summary>
    /// Provides a base class for a repository.
    /// </summary>
    /// <typeparam name="T">The type of objects this repository works with.</typeparam>
    public sealed class RepositoryBase<T> : IRepository<T>
        where T : class {
        /// <inheritdoc/>
        public void Create([NotNull] T obj) {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public void Delete(T obj) {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public T Read() {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public void Update([NotNull] T obj) {
            throw new NotImplementedException();
        }
    }
}