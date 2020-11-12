using JetBrains.Annotations;

namespace OrionShock.Commands {
    /// <summary>
    ///     Describes a command sender.
    /// </summary>
    [PublicAPI]
    public interface ICommandSender {
        /// <summary>
        ///     Sends a message.
        /// </summary>
        /// <param name="message">The message, which must not be <see langword="null" />.</param>
        void SendMessage([NotNull] string message);
    }
}