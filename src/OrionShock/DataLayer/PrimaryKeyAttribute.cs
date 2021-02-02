using System;

namespace OrionShock.DataLayer
{
    /// <summary>
    ///     Marks the given property as a primary key in a table.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class PrimaryKeyAttribute : Attribute
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="PrimaryKeyAttribute" /> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public PrimaryKeyAttribute(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        /// <summary>
        ///     Gets the name.
        /// </summary>
        public string Name { get; }
    }
}