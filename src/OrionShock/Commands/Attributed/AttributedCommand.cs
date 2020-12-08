using System;
using System.Collections.Generic;
using System.Reflection;
using OrionShock.Exceptions;
using OrionShock.Extensions;

namespace OrionShock.Commands.Attributed {
    internal sealed class AttributedCommand : ICommand {
        private readonly ISet<string> _flags = new HashSet<string>();
        private readonly object _handlerObject;
        private readonly ISet<MethodInfo> _handlers;
        private readonly ISet<string> _options = new HashSet<string>();
        private readonly Parsers _parsers;

        /// <summary>
        ///     Initializes a new instance of the <see cref="AttributedCommand" /> class.
        /// </summary>
        /// <param name="parsers">The parsers used to parse this command's parameters.</param>
        /// <param name="name">The name.</param>
        /// <param name="description">The description.</param>
        /// <param name="allowConsole">A value indicating whether the console can execute this command.</param>
        /// <param name="handler">The handler method.</param>
        /// <param name="handlerObject">The handler object.</param>
        public AttributedCommand(
            Parsers parsers,
            string name,
            string description,
            bool allowConsole,
            MethodInfo handler,
            object handlerObject = null) {
            _handlers = new HashSet<MethodInfo> {handler};
            _handlerObject = handlerObject;
            _parsers = parsers ?? throw new ArgumentNullException(nameof(parsers));

            //var parameters = _handler.GetParameters().ToArray();
            //for (var i = 0; i < parameters.Length; ++i) {
            //    var parameter = parameters[i];
            //    var optionAttribute = parameter.GetCustomAttribute<OptionAttribute>();
            //    if (optionAttribute is null && !parameter.IsOptional) {
            //        continue;
            //    }

            //    AddOptionalParameter(parameter.ParameterType == typeof(bool) ? _flags : _options, optionAttribute,
            //        parameter.Name);
            //}

            Name = name ?? throw new ArgumentNullException(nameof(name));
            Description = description ?? throw new ArgumentNullException(nameof(description));
            AllowConsole = allowConsole;

            //static void AddOptionalParameter(ISet<string> set, OptionAttribute optionAttribute, string fallbackName) {
            //    if (optionAttribute is null) {
            //        set.Add(fallbackName);
            //        return;
            //    }

            //    set.Add(optionAttribute.LongName);
            //    if (optionAttribute.ShortIdentifier != default) {
            //        set.Add(optionAttribute.ShortIdentifier.ToString());
            //    }
            //}
        }

        /// <inheritdoc />
        public bool AllowConsole { get; }

        /// <inheritdoc />
        public string Description { get; }

        /// <inheritdoc />
        public string Name { get; }

        /// <inheritdoc />
        public void Execute(CommandContext context) {
            var commandInputMetadata = CommandInputMetadata.Parse(context.CommandLine, new[] {Name});
            var args = BindParameters(context.Sender, commandInputMetadata);
            try {
                //_handler.Invoke(_handler.IsStatic ? null : _handlerObject, args);
            }
            catch (TargetInvocationException ex) {
                context.Sender.SendMessage($"An error has occured while executing the command:\n{ex.Message}");
                throw;
            }
        }

        private object[] BindParameters(ICommandSender sender, CommandInputMetadata inputMetadata) {
            //var parameters = _handler.GetParameters().ToArray();
            //var arguments = new object[parameters.Length];
            //var requiredArgumentIndex = 0;
            //for (var i = 0; i < parameters.Length; ++i) {
            //    var parameter = parameters[i];
            //    if (parameter.ParameterType == typeof(ICommandSender)) {
            //        arguments[i] = sender;
            //        continue;
            //    }

            //    var parser = _parsers.GetParser(parameter.ParameterType);
            //    if (parser is null) {
            //        throw new MissingParserException(parameter.ParameterType.Name);
            //    }

            //    var optionAttribute = parameter.GetCustomAttribute<OptionAttribute>();
            //    if (optionAttribute is null) {
            //        if (!parameter.IsOptional) {
            //            if (requiredArgumentIndex >= inputMetadata.RequiredArguments.Count) {
            //                throw new CommandSyntaxException("Insufficient number of arguments.");
            //            }

            //            arguments[i] = parser(inputMetadata.RequiredArguments[requiredArgumentIndex++]);
            //        }
            //        else {
            //            arguments[i] = inputMetadata.Options.TryGetValue(parameter.Name, out var optionValue)
            //                ? parser(optionValue)
            //                : parameter.ParameterType.GetDefaultValue();
            //        }
            //    }
            //    else {
            //        var optionValue = inputMetadata.Options.GetValueOrDefault(
            //            optionAttribute.LongName, inputMetadata.Options.GetValueOrDefault(optionAttribute.ShortIdentifier.ToString()));
            //        arguments[i] = optionValue == default
            //            ? parameter.ParameterType.GetDefaultValue()
            //            : parser(optionValue);
            //    }
            //}

            //return arguments;
            return null;
        }

        private static MethodInfo ResolveMethod(
            MethodInfo[] methods,
            CommandContext commandContext,
            CommandInputMetadata commandInput,
            out object[] args)
        {
            args = Array.Empty<object>();
            var bestScore = default(double);
            var result = default(MethodInfo);
            for (var i = 0; i < methods.Length; ++i) {
                var method = methods[i];
                var parameters = method.GetParameters();
                if (parameters.Length == 0 && commandInput.RequiredArguments.Count == 0) {
                    return method;
                }

                var score = EvaluateMethodScore(parameters, out var parsedArgs);
                if (score > bestScore) {
                    bestScore = score;
                    args = parsedArgs;
                    result = method;
                }
            }

            return result;

            double EvaluateMethodScore(ParameterInfo[] parameters, out object[] args) {
                args = new object[parameters.Length];
                var explicitArgumentCount = 0;
                var implicitArgumentCount = 0;
                var requiredArgumentIndex = 0;
                for (var i = 0; i < parameters.Length; ++i) {
                    var parameter = parameters[i];
                    if (parameter.IsOut || parameter.ParameterType.IsByRef) {
                        ++implicitArgumentCount;
                        continue;
                    }

                    if (parameter.ParameterType == typeof(CommandContext)) {
                        args[i] = commandContext;
                        ++implicitArgumentCount;
                        continue;
                    }

                    var parser = Parsers.Instance.GetParser(parameter.ParameterType);
                    if (parser is null) {
                        throw new MissingParserException(parameter.ParameterType.Name);
                    }

                    var optionAttribute = parameter.GetCustomAttribute<OptionAttribute>();
                    if (optionAttribute is null) {
                        if (!parameter.IsOptional) {
                            if (requiredArgumentIndex >= commandInput.RequiredArguments.Count) {
                                // throw new CommandSyntaxException("Insufficient number of arguments.");
                                break;
                            }

                            args[i] = parser(commandInput.RequiredArguments[requiredArgumentIndex++]);
                            ++explicitArgumentCount;
                        }
                        else {
                            args[i] = commandInput.Options.TryGetValue(parameter.Name, out var optionValue)
                                ? parser(optionValue)
                                : parameter.ParameterType.GetDefaultValue();
                        }
                    }
                    else {
                        var optionValue = commandInput.Options.GetValueOrDefault(
                            optionAttribute.LongName,
                            commandInput.Options.GetValueOrDefault(optionAttribute.ShortIdentifier.ToString()));
                        args[i] = optionValue == default
                            ? parameter.ParameterType.GetDefaultValue()
                            : parser(optionValue);
                        ++implicitArgumentCount;
                    }
                }

                if (explicitArgumentCount != parameters.Length - implicitArgumentCount) {
                    return -1;
                }

                return (double) explicitArgumentCount / parameters.Length;
            }
        }
    }
}