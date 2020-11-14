using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OrionShock.Database {
    /// <summary>
    /// Represents a base class for a data model (i.e, a table).
    /// </summary>
    public abstract class DataModel {
        /// <summary>
        /// Gets the table name.
        /// </summary>
        internal string TableName {
            get {
                var type = GetType();
                return type.GetCustomAttribute<TableAttribute>()?.Name ?? type.Name;
            }
        }

        /// <summary>
        /// Gets an iterator over column definitions inferred from properties annotated with the <see cref="ColumnAttribute"/>.
        /// </summary>
        /// <returns>An enumerable collection of column definitions.</returns>
        internal IEnumerable<ColumnDefinitionMetadata> GetColumns() {
            var type = GetType();

            // var isOptIn = type.GetCustomAttribute<TableAttribute>()?.SchemaCreationOption == SchemaCreationOptions.OptIn;
            var properties = type.GetProperties();
            for (var i = 0; i < properties.Length; ++i) {
                var property = properties[i];
                var columnAttribute = property.GetCustomAttribute<ColumnAttribute>();
                if (columnAttribute is null) {
                    continue;
                }

                yield return new ColumnDefinitionMetadata(
                    columnAttribute.Name,
                    columnAttribute.IsUnique,
                    type.GetCustomAttribute<PrimaryKeyAttribute>() is not null,
                    property.PropertyType);
            }
        }
    }
}