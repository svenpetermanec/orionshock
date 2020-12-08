using System;
using System.Linq;
using Orion.Core.Events;
using Orion.Core.Events.Players;
using Orion.Core.Packets.DataStructures;
using Orion.Core.Players;
using Orion.Core.Utils;
using OrionShock.Commands.Attributed;

namespace OrionShock {
    internal sealed partial class EventHandlers {
        [EventHandler("orionshock-players", Priority = EventPriority.Normal)]
        public void HandlePlayerChat(PlayerChatEvent @event) {
            if (!@event.Command.Equals("say", StringComparison.InvariantCulture)) {
                return;
            }

            var message = @event.Message;
            if (string.IsNullOrWhiteSpace(message)) {
                return;
            }

            var config = _configurationService.Configuration;
            if (!message.StartsWith(config.CommandSpecifier) && !message.StartsWith(config.CommandSilentSpecifier)) {
                return;
            }

            try {
                var commands = _commandService.GetCommands().ToList();
                var commandInput = CommandInputMetadata.Parse(message, commands.Select(c => c.Name).ToList());
                if (string.IsNullOrWhiteSpace(commandInput.CommandName)) {
                    @event.Player.SendMessage(
                        new NetworkText(NetworkTextMode.Literal, "Invalid command input."), Color3.White);
                }
            }
            catch (Exception e) {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}