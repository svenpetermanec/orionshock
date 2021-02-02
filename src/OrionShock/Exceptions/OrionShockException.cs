using System;
using JetBrains.Annotations;

namespace OrionShock.Exceptions
{
    /// <summary>
    ///     Represents an OrionShock exception.
    /// </summary>
    public class OrionShockException : Exception
    {
        /// <inheritdoc />
        public OrionShockException([CanBeNull] string message) : base(message)
        {
        }

        /// <inheritdoc />
        public OrionShockException([CanBeNull] string message, [CanBeNull] Exception innerException) : base(message,
            innerException)
        {
        }
    }
}