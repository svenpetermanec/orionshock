using System;
using System.Data;
using System.Data.Common;
using Dapper;
using JetBrains.Annotations;
using Orion.Core;
using OrionShock.Configuration;

namespace OrionShock.DataLayer {
    /// <summary>
    /// Provides a base class for a repository.
    /// </summary>
    /// <typeparam name="T">The type of objects this repository works with.</typeparam>
    public abstract class RepositoryBase<T> : IRepository<T> {
        private readonly IConfigurationService<OrionShockConfig> _configurationService;

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryBase{T}"/> class.
        /// </summary>
        /// <param name="configurationService">The configuration service instance.</param>
        protected RepositoryBase(IConfigurationService<OrionShockConfig> configurationService) {
            _configurationService = configurationService ?? throw new ArgumentNullException(nameof(configurationService));
        }

        /// <inheritdoc/>
        public abstract void Create([NotNull] T obj);

        /// <inheritdoc/>
        public abstract void Delete(T obj);

        /// <inheritdoc/>
        public abstract T Read();

        /// <inheritdoc/>
        public abstract void Update([NotNull] T obj);

        /// <summary>
        /// Opens a SQLite database connection.
        /// </summary>
        /// <param name="name">The name the connection string is stored under.</param>
        /// <returns>The connection.</returns>
        private protected IDbConnection OpenConnection(string name = "Default") {
            var connectionString = _configurationService.Configuration.GetConnectionString(name);
            if (connectionString == default) {
                throw new ArgumentException($"No connection string found for '{name}'", nameof(name));
            }

            var connection = new System.Data.SQLite.SQLiteConnection(connectionString);
            connection.Open();
            return connection;
        }
    }
}