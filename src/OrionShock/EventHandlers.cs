using System;
using OrionShock.Commands;
using OrionShock.Configuration;

namespace OrionShock {
    /// <summary>
    /// Provides methods that handle various Orion events.
    /// </summary>
    internal sealed partial class EventHandlers {
        private readonly ICommandService _commandService;
        private readonly IConfigurationService<OrionShockConfig> _configurationService;

        /// <summary>
        /// Initializes a new instance of the <see cref="EventHandlers"/> class.
        /// </summary>
        /// <param name="configurationService">The configuration service instance.</param>
        /// <param name="commandService">The command service instance.</param>
        public EventHandlers(IConfigurationService<OrionShockConfig> configurationService, ICommandService commandService) {
            _configurationService =
                configurationService ?? throw new ArgumentNullException(nameof(configurationService));
            _commandService = commandService ?? throw new ArgumentNullException(nameof(commandService));
        }
    }
}
