using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using OrionShock.DataLayer;

namespace OrionShock.Extensions {
    /// <summary>
    /// <summary>
    /// Provides extension methods for the <see cref="IDbConnection"/> type.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1649:File name should match first type name", Justification = "Personal style")]
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
        /// Creates a table that stores entities of type <typeparamref name="T"/>.
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

            AppendColumn();
            while (columnDefinitionEnumerator.MoveNext()) {
                Debug.Assert(columnDefinitionEnumerator.Current != null, "columnDefinitionEnumerator.Current != null");
                tableBuilder.Append(',');
                AppendColumn();
            }

            tableBuilder.Append(");");
            connection.Execute(tableBuilder.ToString());

            void AppendColumn() {
                var sqliteType = NetToSqliteTypeMapping.GetValueOrDefault(columnDefinitionEnumerator.Current.DataType);
                if (sqliteType == default) {
                    throw new NotSupportedException($"No matching SQLite type found for '{columnDefinitionEnumerator.Current.DataType}'");
                }

                tableBuilder.Append($" {columnDefinitionEnumerator.Current.Name} {sqliteType}");
                if (columnDefinitionEnumerator.Current.IsPrimaryKey) {
                    tableBuilder.Append(" PRIMARY KEY NOT NULL");
                }
                else if (!typeof(Nullable<>).IsAssignableFrom(columnDefinitionEnumerator.Current.DataType)) {
                    tableBuilder.Append(" NOT NULL");
                }

                if (columnDefinitionEnumerator.Current.IsUnique) {
                    tableBuilder.Append(" UNIQUE");
                }
            }
        }
    }
}