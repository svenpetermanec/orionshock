using JetBrains.Annotations;
using System;

namespace OrionShock.Commands.Attributed {

    /// <summary>
    ///     Describes a command.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    [PublicAPI]
    public class CommandAttribute : Attribute {

        /// <summary>
        ///     Initializes a new instance of the <see cref="CommandAttribute" /> class with the specified name and description.
        /// </summary>
        /// <param name="name">The name, which must not be <see langword="null" /> or empty.</param>
        /// <param name="description">The description, which must not be <see langword="null" /> or empty.</param>
        /// <exception cref="ArgumentException">
        ///     <paramref name="name" /> or <paramref name="description" /> is
        ///     <see langword="null" /> or empty.
        /// </exception>
        public CommandAttribute(string name, string description) {
            if (string.IsNullOrWhiteSpace(name)) {
                throw new ArgumentException(nameof(name));
            }

            if (string.IsNullOrWhiteSpace(description)) {
                throw new ArgumentException(nameof(description));
            }

            Name = name;
            Description = description;
        }

        /// <summary>
        ///     Gets or sets a value indicating whether the console should be prevented from executing this command. Defaults to
        ///     <see langword="true" />.
        /// </summary>
        public bool AllowConsole { get; set; } = true;

        /// <summary>
        ///     Gets the description.
        /// </summary>
        public string Description { get; }

        /// <summary>
        ///     Gets the name.
        /// </summary>
        public string Name { get; }
    }
}