using System;
using JetBrains.Annotations;

namespace OrionShock.Exceptions {
    public sealed class ArgumentMismatchException : OrionShockException {
        public ArgumentMismatchException([CanBeNull] string message) : base(message) {
        }

        public ArgumentMismatchException([CanBeNull] string message, [CanBeNull] Exception innerException) : base(message, innerException) {
        }
    }
}