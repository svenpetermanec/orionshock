using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;
using Orion.Core;
using Serilog;

namespace OrionShock.Commands.Attributed {

    [Binding("AttributedCommands", Author = "ivanbiljan", Priority = BindingPriority.Normal)]
    [UsedImplicitly]
    internal sealed class AttributedCommandService : ICommandService {
        private const BindingFlags CommandHandlerBindingFlags =
            BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance;

        private readonly ISet<ICommand> _commands = new HashSet<ICommand>();
        private readonly ILogger _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="AttributedCommandService"/> class.
        /// </summary>
        /// <param name="logger">The logger instance.</param>
        public AttributedCommandService(ILogger logger) {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <inheritdoc />
        public ICommand GetCommand(string name) => _commands.FirstOrDefault(c => c.Name == name);

        /// <inheritdoc />
        public IEnumerable<ICommand> GetCommands(Predicate<ICommand> filter = null) =>
            _commands.Where(c => filter?.Invoke(c) ?? true);

        /// <inheritdoc />
        public void Deregister(object obj) {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public void Register(object obj) {
            var commandHandlers = from method in obj.GetType().GetMethods(CommandHandlerBindingFlags)
                                  let commandAttribute = method.GetCustomAttribute<CommandAttribute>()
                                  where commandAttribute != null
                                  select (commandAttribute, method);
            foreach (var (commandAttribute, handlerMethod) in commandHandlers) {
                if (handlerMethod.ReturnType != typeof(void)) {
                    _logger.Warning($"Command handler '{handlerMethod.Name}' does not return void. Skipping");
                    continue;
                }

                var isConsoleAllowed = handlerMethod.GetCustomAttribute<DisallowConsoleAttribute>() is null;
                var command = new AttributedCommand(Parsers.Instance, commandAttribute.Name, commandAttribute.Description, 
                    isConsoleAllowed, handlerMethod, obj);
                _commands.Add(command);
            }
        }
    }
}