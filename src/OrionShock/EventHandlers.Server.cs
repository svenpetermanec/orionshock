using System;
using System.Diagnostics;
using System.Linq;
using Orion.Core.Events;
using Orion.Core.Events.Server;
using OrionShock.Commands;
using OrionShock.Commands.Attributed;
using OrionShock.Exceptions;

namespace OrionShock {
    internal sealed partial class EventHandlers {
        [EventHandler("orionshock-playerchat", Priority = EventPriority.Normal)]
        public void HandleServerChat(ServerCommandEvent @event) {
            var message = @event.Input;
            if (string.IsNullOrWhiteSpace(message)) {
                return;
            }

            var config = _configurationService.Configuration;
            if (!message.StartsWith(config.CommandSpecifier) && !message.StartsWith(config.CommandSilentSpecifier)) {
                return;
            }

            try {
                message = message[1..];
                var availableCommandNames = _commandService.GetCommands().Select(c => c.Name).ToList();
                var commandInput = CommandInputMetadata.Parse(message, availableCommandNames);
                if (string.IsNullOrWhiteSpace(commandInput.CommandName)) {
                    Console.WriteLine("[OrionShock] Invalid command input.");
                    return;
                }

                var command = _commandService.GetCommand(commandInput.CommandName);
                Debug.Assert(command != null, "command != null");

                command.Execute(new CommandContext(new ConsoleCommandSender(), message));
                @event.Cancel();
            }
            catch (CommandSyntaxException e) {
                Console.WriteLine(e.Message);
            }
        }
    }
}