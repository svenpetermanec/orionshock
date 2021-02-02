using JetBrains.Annotations;
using Orion.Core;

namespace OrionShock.DataLayer
{
    /// <summary>
    ///     Describes a repository. <i>Repositories should implement <see cref="RepositoryBase{T}" />!</i>
    /// </summary>
    /// <typeparam name="T">The type of objects this repository works with.</typeparam>
    [Service(ServiceScope.Transient)]
    public interface IRepository<T>
    {
        /// <summary>
        ///     Inserts a given object into the database.
        /// </summary>
        /// <param name="obj">The object.</param>
        void Create([NotNull] T obj);

        /// <summary>
        ///     Reads a given object from the database.
        /// </summary>
        /// <returns>The read object.</returns>
        T Read();

        /// <summary>
        ///     Updates the given object.
        /// </summary>
        /// <param name="obj">The object.</param>
        void Update([NotNull] T obj);

        /// <summary>
        ///     Deletes the given object.
        /// </summary>
        /// <param name="obj">The object.</param>
        void Delete(T obj);
    }
}