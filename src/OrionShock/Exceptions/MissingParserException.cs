using System;
using JetBrains.Annotations;

namespace OrionShock.Exceptions {
    /// <summary>
    ///     Represents the <see cref="MissingParserException" />
    /// </summary>
    public sealed class MissingParserException : OrionShockException {
        /// <summary>
        ///     Initializes a new instance of the <see cref="MissingParserException" /> class with the specified type name.
        /// </summary>
        /// <param name="typeName">The name of the type that caused the exception.</param>
        public MissingParserException([CanBeNull] string typeName) : base($"Missing parser for type '{typeName}'.") {
        }

        public MissingParserException([CanBeNull] string message, [CanBeNull] Exception innerException) : base(message,
            innerException) {
        }
    }
}