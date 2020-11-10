using System;
using JetBrains.Annotations;

namespace OrionShock.Commands {
    [PublicAPI]
    public sealed class ConsoleCommandSender : ICommandSender {
        public void SendMessage(string message) => SendMessage(message, Console.ForegroundColor);

        public void SendMessage([NotNull] string message, ConsoleColor color) {
            if (message is null) {
                throw new ArgumentNullException(nameof(message));
            }

            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}