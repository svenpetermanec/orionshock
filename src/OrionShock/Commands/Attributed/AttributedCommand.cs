using OrionShock.Exceptions;
using OrionShock.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace OrionShock.Commands.Attributed {

    internal sealed class AttributedCommand : ICommand {
        private readonly ISet<string> _flags = new HashSet<string>();
        private readonly MethodInfo _handler;
        private readonly object _handlerObject;
        private readonly ISet<string> _options = new HashSet<string>();
        private readonly Parsers _parsers;

        /// <summary>
        /// Initializes a new instance of the <see cref="AttributedCommand"/> class.
        /// </summary>
        /// <param name="parsers">The parsers used to parse this command's parameters.</param>
        /// <param name="name">The name.</param>
        /// <param name="description">The description.</param>
        /// <param name="allowConsole">A value indicating whether the console can execute this command.</param>
        /// <param name="handler">The handler method.</param>
        /// <param name="handlerObject">The handler object.</param>
        public AttributedCommand(Parsers parsers, string name, string description, bool allowConsole, MethodInfo handler,
            object handlerObject = null) {
            _handler = handler ?? throw new ArgumentNullException(nameof(handler));
            _handlerObject = handlerObject;
            _parsers = parsers ?? throw new ArgumentNullException(nameof(parsers));

            var parameters = _handler.GetParameters().ToArray();
            for (var i = 0; i < parameters.Length; ++i) {
                var parameter = parameters[i];
                var optionAttribute = parameter.GetCustomAttribute<OptionAttribute>();
                if (optionAttribute is null && !parameter.IsOptional) {
                    continue;
                }

                AddOptionalParameter(parameter.ParameterType == typeof(bool) ? _flags : _options, optionAttribute, parameter.Name);
            }

            Name = name ?? throw new ArgumentNullException(nameof(name));
            Description = description ?? throw new ArgumentNullException(nameof(description));
            AllowConsole = allowConsole;

            static void AddOptionalParameter(ISet<string> set, OptionAttribute optionAttribute, string fallbackName) {
                if (optionAttribute is null) {
                    set.Add(fallbackName);
                    return;
                }

                set.Add(optionAttribute.LongName);
                if (optionAttribute.ShortIdentifier != default) {
                    set.Add(optionAttribute.ShortIdentifier.ToString());
                }
            }
        }

        /// <inheritdoc />
        public bool AllowConsole { get; }

        /// <inheritdoc />
        public string Description { get; }

        /// <inheritdoc />
        public string Name { get; }

        /// <inheritdoc />
        public void Execute(CommandContext context) {
            var commandInputMetadata = CommandInputMetadata.Parse(context.CommandLine, new[] { Name });
            var args = BindParameters(context.Sender, commandInputMetadata);
            try {
                _handler.Invoke(_handler.IsStatic ? null : _handlerObject, args);
            }
            catch (TargetInvocationException ex) {
                context.Sender.SendMessage($"An error has occured while executing the command:\n{ex.Message}");
                throw;
            }
        }

        private object[] BindParameters(ICommandSender sender, CommandInputMetadata inputMetadata) {
            var parameters = _handler.GetParameters().ToArray();
            var arguments = new object[parameters.Length];
            var requiredArgumentIndex = 0;
            for (var i = 0; i < parameters.Length; ++i) {
                var parameter = parameters[i];
                if (parameter.ParameterType == typeof(ICommandSender)) {
                    arguments[i] = sender;
                    continue;
                }

                var parser = _parsers.GetParser(parameter.ParameterType);
                if (parser is null) {
                    throw new MissingParserException(parameter.ParameterType.Name);
                }

                var optionAttribute = parameter.GetCustomAttribute<OptionAttribute>();
                if (optionAttribute is null) {
                    if (!parameter.IsOptional) {
                        if (requiredArgumentIndex >= inputMetadata.RequiredArguments.Count) {
                            throw new ArgumentMismatchException("Insufficient number of arguments.");
                        }

                        arguments[i] = parser(inputMetadata.RequiredArguments[requiredArgumentIndex++]);
                    }
                    else {
                        arguments[i] = inputMetadata.Options.TryGetValue(parameter.Name, out var optionValue)
                            ? parser(optionValue)
                            : parameter.ParameterType.GetDefaultValue();
                    }
                }
                else {
                    var optionValue = inputMetadata.Options.GetValueOrDefault(
                        optionAttribute.LongName, inputMetadata.Options.GetValueOrDefault(optionAttribute.ShortIdentifier.ToString()));
                    arguments[i] = optionValue == default
                        ? parameter.ParameterType.GetDefaultValue()
                        : parser(optionValue);
                }
            }

            return arguments;
        }

        // public void Test(ICommandSender sender, [Option("name")] string option, bool flag, [Option("num")] int number, float required, bool flag2 = false)
    }
}