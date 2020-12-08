using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;
using Orion.Core;
using OrionShock.Extensions;
using Serilog;

namespace OrionShock.Commands.Attributed {
    /// <summary>
    ///     Represents the attributed command service.
    /// </summary>
    [Binding("AttributedCommands", Author = "ivanbiljan", Priority = BindingPriority.Normal)]
    [UsedImplicitly]
    internal sealed class AttributedCommandService : ICommandService {
        private const BindingFlags CommandHandlerBindingFlags =
            BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance;

        private readonly IDictionary<object, ISet<ICommand>> _commands = new Dictionary<object, ISet<ICommand>>();
        private readonly ILogger _logger;

        /// <summary>
        ///     Initializes a new instance of the <see cref="AttributedCommandService" /> class.
        /// </summary>
        /// <param name="logger">The logger instance.</param>
        public AttributedCommandService(ILogger logger) {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <inheritdoc />
        public ICommand GetCommand(string name) {
            return _commands.Values.SelectMany(c => c).FirstOrDefault(c => c.Name == name);
        }

        /// <inheritdoc />
        public IEnumerable<ICommand> GetCommands(Predicate<ICommand> filter = null) {
            return _commands.Values.SelectMany(c => c).Where(c => filter?.Invoke(c) ?? true);
        }

        /// <inheritdoc />
        public void Deregister(object obj) {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public void Register(object obj) {
            if (obj is null) {
                throw new ArgumentNullException(nameof(obj));
            }

            var command = _commands.GetValueOrDefault(obj, new HashSet<ICommand>());
            foreach (var method in obj.GetType().GetMethods(CommandHandlerBindingFlags)) {
                var commandAttribute = method.GetCustomAttribute<CommandAttribute>();
                if (commandAttribute is null) {
                    continue;
                }

                if (method.ReturnType != typeof(void)) {
                    _logger.Warning($"Command handler '{method.Name}' does not return void. Skipping");
                    continue;
                }

                var isConsoleAllowed = method.GetCustomAttribute<DisallowConsoleAttribute>() is null;
            }
        }
    }
}