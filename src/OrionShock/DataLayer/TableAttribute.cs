using System;

namespace OrionShock.DataLayer
{
    /// <summary>
    ///     Describes a table in a database.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class TableAttribute : Attribute
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="TableAttribute" /> class.
        /// </summary>
        /// <param name="name">The name of the table.</param>
        public TableAttribute(string name)
        {
            Name = name;
        }

        /// <summary>
        ///     Gets the table's name.
        /// </summary>
        public string Name { get; }
    }
}