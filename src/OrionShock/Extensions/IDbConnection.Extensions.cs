﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Dapper;
using OrionShock.DataLayer;

namespace OrionShock.Extensions {
    /// <summary>
    ///     <summary>
    ///         Provides extension methods for the <see cref="IDbConnection" /> type.
    ///     </summary>
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1649:File name should match first type name",
        Justification = "Personal style")]
    public static class IDbConnectionExtensions {
        private static readonly IDictionary<Type, string> NetToSqliteTypeMapping = new Dictionary<Type, string> {
            [typeof(bool)] = "INTEGER",
            [typeof(byte)] = "INTEGER",
            [typeof(sbyte)] = "INTEGER",
            [typeof(short)] = "INTEGER",
            [typeof(ushort)] = "INTEGER",
            [typeof(int)] = "INTEGER",
            [typeof(uint)] = "INTEGER",
            [typeof(long)] = "INTEGER",
            [typeof(ulong)] = "INTEGER",
            [typeof(float)] = "REAL",
            [typeof(double)] = "REAL",
            [typeof(string)] = "TEXT",
            [typeof(char)] = "TEXT"
        };

        /// <summary>
        ///     Creates a table that stores entities of type <typeparamref name="T" />.
        /// </summary>
        /// <typeparam name="T">The type of entities this table stores, i.e the model used to interact with the table.</typeparam>
        /// <param name="connection">The database connection.</param>
        public static void CreateTable<T>(this IDbConnection connection)
            where T : DataModelBase, new() {
            if (connection is null) {
                throw new ArgumentNullException(nameof(connection));
            }

            var model = new T();
            var tableBuilder = new StringBuilder($"CREATE TABLE IF NOT EXISTS `{model.TableName}` (");
            using var columnDefinitionEnumerator = model.GetColumns().GetEnumerator();
            if (columnDefinitionEnumerator.Current is null) {
                throw new InvalidOperationException($"Cannot create an empty table ('{model.TableName}').");
            }

            var primaryKeys = new List<string>();

            AppendColumn();
            while (columnDefinitionEnumerator.MoveNext()) {
                Debug.Assert(columnDefinitionEnumerator.Current != null, "columnDefinitionEnumerator.Current != null");
                tableBuilder.Append(',');
                AppendColumn();
            }

            if (primaryKeys.Count > 0) {
                tableBuilder.Append($", PRIMARY KEYS({string.Join(", ", primaryKeys)}");
            }

            tableBuilder.Append(");");
            connection.Execute(tableBuilder.ToString());

            void AppendColumn() {
                var column = columnDefinitionEnumerator.Current;
                var sqliteType = NetToSqliteTypeMapping.GetValueOrDefault(column.DataType);
                if (sqliteType == default) {
                    throw new NotSupportedException($"No matching SQLite type found for '{column.DataType}'");
                }

                tableBuilder.Append($" {column.Name} {sqliteType}");
                if (column.IsPrimaryKey) {
                    primaryKeys.Add(column.Name);
                }
                else if (!typeof(Nullable<>).IsAssignableFrom(column.DataType)) {
                    tableBuilder.Append(" NOT NULL");
                }

                if (column.IsUnique) {
                    tableBuilder.Append(" UNIQUE");
                }
            }
        }
    }
}