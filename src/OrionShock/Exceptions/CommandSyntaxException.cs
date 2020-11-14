using System;
using JetBrains.Annotations;

namespace OrionShock.Exceptions {
    /// <summary>
    /// Represents a command syntax exception.
    /// </summary>
    public sealed class CommandSyntaxException : OrionShockException {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommandSyntaxException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public CommandSyntaxException([CanBeNull] string message) : base(message) {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandSyntaxException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        public CommandSyntaxException([CanBeNull] string message, [CanBeNull] Exception innerException) : base(message, innerException) {
        }
    }
}