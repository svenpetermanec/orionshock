using System;
using System.Collections.Generic;
using System.Reflection;

namespace OrionShock.DataLayer
{
    /// <summary>
    ///     Represents a base class for a data model (i.e, a table).
    /// </summary>
    public abstract class DataModelBase
    {
        /// <summary>
        ///     Gets the table name.
        /// </summary>
        internal string TableName
        {
            get
            {
                var type = GetType();
                return type.GetCustomAttribute<TableAttribute>()?.Name ?? type.Name;
            }
        }

        /// <summary>
        ///     Returns an enumerable collection of column definitions inferred from properties annotated with the
        ///     <see cref="ColumnAttribute" />.
        /// </summary>
        /// <returns>An enumerable collection of column definitions.</returns>
        internal IEnumerable<ColumnDefinitionMetadata> GetColumns()
        {
            var type = GetType();

            // var isOptIn = type.GetCustomAttribute<TableAttribute>()?.SchemaCreationOption == SchemaCreationOptions.OptIn;
            var members = type.GetMembers(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            for (var i = 0; i < members.Length; ++i)
            {
                var member = members[i];
                var columnAttribute = member.GetCustomAttribute<ColumnAttribute>();
                if (columnAttribute is null)
                {
                    continue;
                }

                Type columnType;
                if (member is FieldInfo fieldInfo)
                {
                    columnType = fieldInfo.FieldType;
                }
                else if (member is PropertyInfo propertyInfo)
                {
                    columnType = propertyInfo.PropertyType;
                }
                else
                {
                    continue;
                }

                yield return new ColumnDefinitionMetadata(
                    columnAttribute.Name,
                    columnAttribute.IsUnique,
                    member.GetCustomAttribute<PrimaryKeyAttribute>() is not null,
                    columnType);
            }
        }
    }
}