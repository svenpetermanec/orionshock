using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Orion.Core;

namespace OrionShock.Commands {
    /// <summary>
    ///     Represents a command service.
    /// </summary>
    [PublicAPI]
    [Service(ServiceScope.Singleton)]
    public interface ICommandService {
        /// <summary>
        ///     Deregisters commands defined by the specified object.
        /// </summary>
        /// <param name="obj">The object, which must not be <see langword="null" />.</param>
        void Deregister([NotNull] object obj);

        /// <summary>
        ///     Gets the command that best matches the given name.
        /// </summary>
        /// <param name="name">The name, which must not be <see langword="null" />.</param>
        /// <returns>The command that best matches the given name.</returns>
        [CanBeNull]
        ICommand GetCommand([NotNull] string name);

        /// <summary>
        ///     Gets a list of commands, optionally matches the specified predicate.
        /// </summary>
        /// <param name="filter">The predicate used to filter the commands.</param>
        /// <returns>A list of commands matching the criteria.</returns>
        [ItemNotNull]
        IEnumerable<ICommand> GetCommands(Predicate<ICommand> filter = null);

        /// <summary>
        ///     Registers commands defined by the specified object.
        /// </summary>
        /// <param name="obj">The object, which must not be <see langword="null" />.</param>
        void Register([NotNull] object obj);
    }
}