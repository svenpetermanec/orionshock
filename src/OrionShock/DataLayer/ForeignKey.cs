using System.Collections.Generic;
using System.Collections.Immutable;

namespace OrionShock.DataLayer
{
    /// <summary>
    ///     Represents a foreign key in a table.
    /// </summary>
    internal sealed class ForeignKey
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ForeignKey" /> class.
        /// </summary>
        /// <param name="columns">The columns that comprise the foreign key.</param>
        /// <param name="referencedTable">The referenced table.</param>
        /// <param name="referencedColumns">The referenced columns.</param>
        public ForeignKey(IEnumerable<string> columns, string referencedTable, IEnumerable<string> referencedColumns)
        {
            Columns = columns.ToImmutableArray();
            ReferencedTable = referencedTable;
            ReferencedColumns = referencedColumns.ToImmutableArray();
        }

        /// <summary>
        ///     Gets an immutable array of columns that comprise the foreign key.
        /// </summary>
        public ImmutableArray<string> Columns { get; }

        /// <summary>
        ///     Gets the referenced table.
        /// </summary>
        public string ReferencedTable { get; }

        /// <summary>
        ///     Gets an immutable array of columns that comprise the foreign key.
        /// </summary>
        public ImmutableArray<string> ReferencedColumns { get; }
    }
}