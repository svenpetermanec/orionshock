using System;
using JetBrains.Annotations;
using Orion.Core.Packets.DataStructures;
using Orion.Core.Players;
using Orion.Core.Utils;

namespace OrionShock.Commands {
    [PublicAPI]
    public sealed class PlayerCommandSender : ICommandSender {
        private readonly IPlayer _player;

        internal PlayerCommandSender(IPlayer player) {
            _player = player ?? throw new ArgumentNullException(nameof(player));
        }

        public void SendMessage(string message) => SendMessage(message, Color3.White);

        public void SendMessage([NotNull] string message, Color3 color3) {
            if (message is null) {
                throw new ArgumentNullException(nameof(message));
            }

            _player.SendMessage(new NetworkText(NetworkTextMode.Literal, message), color3);
        }
    }

    public static class PlayerCommandSenderExtensions {
        public static void SendErrorMessage(this PlayerCommandSender sender, string message) =>
            sender.SendMessage(message, new Color3(255, 0, 0));

        public static void SendInfoMessage(this PlayerCommandSender sender, string message) =>
            sender.SendMessage(message, new Color3(255, 255, 0));

        public static void SendSuccessMessage(this PlayerCommandSender sender, string message) =>
            sender.SendMessage(message, new Color3(0, 255, 0));
    }
}