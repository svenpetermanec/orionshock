using System;

namespace OrionShock.Commands.Attributed {
    /// <summary>
    ///     Applied to command handlers to indicate that a given command cannot be executed from the console.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public sealed class DisallowConsoleAttribute : Attribute {
    }
}