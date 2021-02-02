using System;
using System.Collections.Generic;
using OrionShock.Extensions;

namespace OrionShock.Configuration
{
    /// <summary>
    ///     Represents the `OrionShock` configuration file.
    /// </summary>
    public sealed class OrionShockConfig
    {
        private readonly IDictionary<string, string> _connectionStrings = new Dictionary<string, string>();

        /// <summary>
        ///     Gets or sets the silent command prefix.
        /// </summary>
        public string CommandSilentSpecifier { get; set; } = ".";

        /// <summary>
        ///     Gets or sets the command prefix.
        /// </summary>
        public string CommandSpecifier { get; set; } = "/";

        /// <summary>
        ///     Gets a dictionary of connection strings.
        /// </summary>
        public IDictionary<string, string> ConnectionStrings { get; } = new Dictionary<string, string>
        {
            ["Default"] = string.Empty
        };

        /// <summary>
        ///     Gets a connection string stored under the specified name, or <see langword="null" /> if no such connection exists.
        /// </summary>
        /// <param name="name">The name the connection is stored under.</param>
        /// <returns>The connection string, or <see langword="null" /> if no such connection exists.</returns>
        public string GetConnectionString(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Invalid connection string name.", nameof(name));
            }

            return _connectionStrings.GetValueOrDefault(name);
        }

        /// <summary>
        ///     Stores a connection string under the specified name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="connectionString">The connection string.</param>
        public void SetConnectionString(string name, string connectionString)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(nameof(name));
            }

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new ArgumentException(nameof(connectionString));
            }

            if (_connectionStrings.ContainsKey(name))
            {
                throw new ArgumentException($"Name '{name}' is in use", nameof(name));
            }

            _connectionStrings[name] = connectionString;
        }
    }
}