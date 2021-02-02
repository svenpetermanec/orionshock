using JetBrains.Annotations;

namespace OrionShock.Commands
{
    /// <summary>
    ///     Describes a command.
    /// </summary>
    [PublicAPI]
    public interface ICommand
    {
        /// <summary>
        ///     Gets a value indicating whether the console can execute the command.
        /// </summary>
        bool AllowConsole { get; }

        /// <summary>
        ///     Gets the description.
        /// </summary>
        string Description { get; }

        /// <summary>
        ///     Gets the name.
        /// </summary>
        string Name { get; }

        /// <summary>
        ///     Executes the command.
        /// </summary>
        /// <param name="context">The command context.</param>
        void Execute(CommandContext context);
    }
}