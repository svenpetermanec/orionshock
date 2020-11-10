using JetBrains.Annotations;
using Orion.Core;
using Orion.Core.Events;
using OrionShock.Commands;
using OrionShock.Configuration;
using Serilog;

namespace OrionShock {
    /// <summary>
    ///     Represents the main entry point for the `OrionShock` plugin.
    /// </summary>
    [Plugin("OrionShock", Author = "ivanbiljan")]
    [UsedImplicitly]
    public sealed class OrionShockPlugin : OrionPlugin {
        public OrionShockPlugin(IServer server, ILogger log, IConfigurationService<OrionShockConfig> configurationService, ICommandService commandService) : base(server, log) {
            // Set up event handlers
            server.Events.RegisterHandlers(new EventHandlers(configurationService, commandService), log);
            
            // Register OrionShock commands
            commandService.Register(new OrionShockCommands(server));
        }
    } 
}