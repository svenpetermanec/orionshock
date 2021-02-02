using System;
using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;
using Orion.Core.Packets.DataStructures;
using Orion.Core.Players;
using Orion.Core.Utils;
using Remus;

namespace OrionShock.Commands
{
    /// <summary>
    ///     Provides extension methods for the <see cref="PlayerCommandSender" /> type.
    /// </summary>
    public static class PlayerCommandSenderExtensions
    {
        /// <summary>
        ///     Sends an error message.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="message">The message.</param>
        public static void SendErrorMessage(this PlayerCommandSender sender, string message)
        {
            sender.SendMessage(message, new Color3(255, 0, 0));
        }

        /// <summary>
        ///     Sends an info message.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="message">The message.</param>
        public static void SendInfoMessage(this PlayerCommandSender sender, string message)
        {
            sender.SendMessage(message, new Color3(255, 255, 0));
        }

        /// <summary>
        ///     Sends a success message.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="message">The message.</param>
        public static void SendSuccessMessage(this PlayerCommandSender sender, string message)
        {
            sender.SendMessage(message, new Color3(0, 255, 0));
        }
    }

    /// <summary>
    ///     Represents a player command sender.
    /// </summary>
    [PublicAPI]
    public sealed class PlayerCommandSender : ICommandSender
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="PlayerCommandSender" /> class.
        /// </summary>
        /// <param name="player">The player.</param>
        internal PlayerCommandSender(IPlayer player)
        {
            Player = player ?? throw new ArgumentNullException(nameof(player));
        }

        /// <summary>
        ///     Gets the player.
        /// </summary>
        public IPlayer Player { get; }

        /// <inheritdoc />
        public void SendMessage(string message)
        {
            SendMessage(message, Color3.White);
        }

        /// <summary>
        ///     Sends a message in the specified color.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="color3">The color.</param>
        public void SendMessage([JetBrains.Annotations.NotNull] string message, Color3 color3)
        {
            if (message is null)
            {
                throw new ArgumentNullException(nameof(message));
            }

            Player.SendMessage(new NetworkText(NetworkTextMode.Literal, message), color3);
        }
    }
}