using JetBrains.Annotations;
using System;

namespace OrionShock.Commands.Attributed {

    /// <summary>
    ///     Describes a command option.
    /// </summary>
    [AttributeUsage(AttributeTargets.Parameter)]
    [PublicAPI]
    public sealed class OptionAttribute : Attribute {

        /// <summary>
        ///     Initializes a new instance of the <see cref="OptionAttribute" /> with the specified name.
        /// </summary>
        /// <param name="longName">The name, which must not be <see langword="null" />.</param>
        /// <exception cref="ArgumentNullException"><paramref name="longName" /> is <see langword="null" />.</exception>
        public OptionAttribute(string longName) {
            LongName = longName ?? throw new ArgumentNullException(nameof(longName));
        }

        /// <summary>
        ///     Gets the long name.
        /// </summary>
        public string LongName { get; }

        /// <summary>
        ///     Gets or sets the short identifier.
        /// </summary>
        public char ShortIdentifier { get; set; }
    }
}