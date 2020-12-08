using System;
using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;

namespace OrionShock.Commands {
    /// <summary>
    ///     Represents a console sender.
    /// </summary>
    [PublicAPI]
    public sealed class ConsoleCommandSender : ICommandSender {
        /// <inheritdoc />
        public void SendMessage(string message) {
            SendMessage(message, Console.ForegroundColor);
        }


        /// <summary>
        ///     Sends a message in the specified color.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="color">The color.</param>
        [SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "Base overload.")]
        public void SendMessage([JetBrains.Annotations.NotNull] string message, ConsoleColor color) {
            if (message is null) {
                throw new ArgumentNullException(nameof(message));
            }

            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}