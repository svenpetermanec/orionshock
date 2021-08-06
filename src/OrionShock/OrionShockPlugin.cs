using System;
using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;
using Orion.Core;
using Orion.Core.Events;
using OrionShock.Commands;
using OrionShock.Configuration;
using Remus.Extensions;
using Serilog;

namespace OrionShock
{
    /// <summary>
    ///     Represents the main entry point for the `OrionShock` plugin.
    /// </summary>
    [Plugin("OrionShock", Author = "ivanbiljan")]
    [UsedImplicitly]
    public sealed class OrionShockPlugin : OrionPlugin
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="OrionShockPlugin" /> class.
        /// </summary>
        /// <param name="server">The server instance.</param>
        /// <param name="log">The logger instance-</param>
        /// <param name="configurationService">The configuration service instance.</param>
        /// <param name="commandService">The command service instance.</param>
        public OrionShockPlugin(
            IServer server,
            ILogger log,
            IConfigurationService<OrionShockConfig> configurationService,
            ICommandService commandService)
            : base(server, log)
        {
            var serviceProvider = new ServiceCollection().AddRemus().BuildServiceProvider();
                
            // Set up event handlers
            server.Events.RegisterHandlers(new EventHandlers(configurationService, commandService), log);
        }
    }
}