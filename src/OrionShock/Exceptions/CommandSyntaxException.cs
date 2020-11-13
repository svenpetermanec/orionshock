using System;
using JetBrains.Annotations;

namespace OrionShock.Exceptions {
    public sealed class CommandSyntaxException : OrionShockException {
        public CommandSyntaxException([CanBeNull] string message) : base(message) {
        }

        public CommandSyntaxException([CanBeNull] string message, [CanBeNull] Exception innerException) : base(message, innerException) {
        }
    }
}