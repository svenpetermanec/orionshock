using System;
using System.Linq;
using Orion.Core.Events;
using Orion.Core.Events.Players;
using Orion.Core.Packets.DataStructures;
using Orion.Core.Players;
using Orion.Core.Utils;
using OrionShock.Commands;
using OrionShock.Commands.Attributed;
using OrionShock.Configuration;

namespace OrionShock {
    internal sealed partial class EventHandlers {
        private readonly ICommandService _commandService;
        private readonly IConfigurationService<OrionShockConfig> _configurationService;

        public EventHandlers(IConfigurationService<OrionShockConfig> configurationService, ICommandService commandService) {
            _configurationService =
                configurationService ?? throw new ArgumentNullException(nameof(configurationService));
            _commandService = commandService ?? throw new ArgumentNullException(nameof(commandService));
        }
        
        [EventHandler("orionshock-playerchat", Priority = EventPriority.Normal)]
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
                    @event.Player.SendMessage(new NetworkText(NetworkTextMode.Literal, "Invalid command input."),
                        Color3.White);
                    return;
                }
            }
            catch (Exception e) {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}