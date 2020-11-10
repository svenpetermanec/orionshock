using JetBrains.Annotations;

namespace OrionShock.Commands {
    /// <summary>
    ///     Represents a command context.
    /// </summary>
    [PublicAPI]
    public readonly struct CommandContext {
        /// <summary>
        ///     Initializes a new instance of the <see cref="CommandContext" /> structure with the specified sender and
        ///     command line.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="commandLine">The full command-line representation of the command.</param>
        internal CommandContext(ICommandSender sender, string commandLine) {
            Sender = sender;
            CommandLine = commandLine;
        }

        /// <summary>
        ///     Gets the sender.
        /// </summary>
        public ICommandSender Sender { get; }

        /// <summary>
        ///     Gets the full command-line representation of the command.
        /// </summary>
        public string CommandLine { get; }
    }
}