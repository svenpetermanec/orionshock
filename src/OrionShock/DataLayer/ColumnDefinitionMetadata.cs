using System;

namespace OrionShock.DataLayer
{
    /// <summary>
    ///     Describes a column in a table.
    /// </summary>
    internal sealed class ColumnDefinitionMetadata
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ColumnDefinitionMetadata" /> class.
        /// </summary>
        /// <param name="name">The column's name.</param>
        /// <param name="isUnique">A value indicating whether the column is unique.</param>
        /// <param name="isPrimaryKey">A value indicating whether the column is a primary key.</param>
        /// <param name="dataType">The type of data this column stores.</param>
        public ColumnDefinitionMetadata(string name, bool isUnique, bool isPrimaryKey, Type dataType)
        {
            Name = name;
            IsUnique = isUnique;
            IsPrimaryKey = isPrimaryKey;
            DataType = dataType;
        }

        /// <summary>
        ///     Gets the name.
        /// </summary>
        public string Name { get; }

        /// <summary>
        ///     Gets a value indicating whether the column is unique.
        /// </summary>
        public bool IsUnique { get; }

        /// <summary>
        ///     Gets a value indicating whether the column is a primary key.
        /// </summary>
        public bool IsPrimaryKey { get; }

        /// <summary>
        ///     Gets the type of data this column stores.
        /// </summary>
        public Type DataType { get; }
    }
}