using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace OrionShock.Commands.Attributed {
    /// <summary>
    ///     Represents a command input analyzer. This class lexes an input string to extract meaningful information.
    /// </summary>
    internal sealed class CommandInputMetadata {
        // Generic command syntax: commandname requiredArg1 requiredArg2 "required arg 3" [options/flags]
        // This library originally followed a "Unix convention" where the general syntax is command name [options] args...
        // However, given that there is no context on the command we're parsing such approach makes option parsing
        // too cumbersome as there is no way to tell whether the last option in the list takes an argument or if the
        // following token represents one of the required arguments
        // E.g testcommand --booleanflag --option EitherOptionValueOrRequiredArgument requiredArg requiredArg2

        private CommandInputMetadata() {
            // Don't expose the constructor
            // Callers should rely on the Parse() method
        }

        /// <summary>
        ///     Gets the command name.
        /// </summary>
        public string CommandName { get; private set; }

        /// <summary>
        ///     Gets a read-only collection of option-value pairs.
        /// </summary>
        public IReadOnlyDictionary<string, string> Options { get; private set; }

        /// <summary>
        ///     Gets a read-only collection of required arguments.
        /// </summary>
        public IReadOnlyList<string> RequiredArguments { get; private set; }

        /// <summary>
        ///     Parses a given input string by trying to match it against a list of available command names.
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <param name="availableCommandNames">A readonly collection of available command names.</param>
        /// <returns>The metadata.</returns>
        public static CommandInputMetadata Parse(string input, IReadOnlyCollection<string> availableCommandNames) {
            if (string.IsNullOrWhiteSpace(input)) {
                throw new ArgumentException(nameof(input));
            }

            var index = 0;
            var tokens = TokenizeInput(input);
            var commandName = ParseCommandName(availableCommandNames, tokens, ref index);
            var arguments = ParseArguments(tokens, ref index);
            var options = ParseOptionals(tokens, ref index);
            return new CommandInputMetadata {
                CommandName = commandName,
                Options = options,
                RequiredArguments = arguments
            };
        }

        private static List<string> ParseArguments(IReadOnlyList<string> tokens, ref int index) {
            var arguments = new List<string>();
            for (; index < tokens.Count; ++index) {
                if (tokens[index][0] == '-') {
                    break;
                }

                arguments.Add(tokens[index]);
            }

            return arguments;
        }

        private static string ParseCommandName(
            IReadOnlyCollection<string> availableCommandNames,
            IReadOnlyList<string> tokens,
            ref int index) {
            Debug.Assert(tokens.Count > 0, "tokens > 0");

            var commandName = default(string);
            var i = 1;
            var builder = new StringBuilder(tokens[0]);
            do {
                var tempCommand = builder.ToString();
                if (!availableCommandNames.Contains(tempCommand)) {
                    break;
                }

                commandName = tempCommand;
                index = i;
                builder.Append(" " + tokens.ElementAtOrDefault(i));
            } while (i < tokens.Count);

            return commandName;
        }

        private static Dictionary<string, string> ParseOptionals(
            IReadOnlyList<string> tokens,
            ref int index) {
            var currentOption = default(string);
            var options = new Dictionary<string, string>();
            for (var i = index; i < tokens.Count; ++i) {
                var token = tokens[index];
                if (!token.StartsWith("-")) {
                    // No options left to consume
                    if (currentOption == default) {
                        break;
                    }

                    options[currentOption] = token;
                    currentOption = default;
                    ++index;
                    continue;
                }

                if (!token.StartsWith("--")) {
                    currentOption = token[1].ToString();
                }
                else {
                    currentOption = token[2..];
                    var indexOfEquals = currentOption.IndexOf('=');
                    if (indexOfEquals > 0) {
                        options[currentOption[..indexOfEquals]] = currentOption[(indexOfEquals + 1)..];
                        currentOption = default;
                    }
                }

                ++index;
            }

            return options;
        }

        /// <summary>
        ///     Parses arguments from the specified input string. Supports quotation marks and escape characters.
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <returns>A read-only list of tokens (arguments) extracted from the input string.</returns>
        private static IReadOnlyList<string> TokenizeInput(string input) {
            var arguments = new List<string>();
            var stringBuilder = new StringBuilder(input.Length);
            var inQuotes = false;
            var isEscaped = false;
            foreach (var currentCharacter in input) {
                switch (currentCharacter) {
                    case '\\': {
                        if (isEscaped) {
                            stringBuilder.Append(currentCharacter);
                            isEscaped = false;
                            continue;
                        }

                        isEscaped = true;
                        break;
                    }

                    case ' ':
                    case '\t':
                    case '\n': {
                        if (inQuotes || isEscaped) {
                            stringBuilder.Append(currentCharacter);
                            isEscaped = false;
                        }
                        else {
                            if (stringBuilder.Length == 0) {
                                continue;
                            }

                            CommitPendingArgument();
                        }

                        break;
                    }

                    case '"': {
                        if (isEscaped) {
                            stringBuilder.Append(currentCharacter);
                            isEscaped = false;
                            continue;
                        }

                        inQuotes = !inQuotes;
                        if (inQuotes) {
                            continue;
                        }

                        CommitPendingArgument();
                        break;
                    }

                    default:
                        stringBuilder.Append(currentCharacter);
                        break;
                }
            }

            CommitPendingArgument();
            return arguments;

            void CommitPendingArgument() {
                if (stringBuilder.Length == 0) {
                    return;
                }

                arguments.Add(stringBuilder.ToString());
                stringBuilder.Clear();
            }
        }
    }
}