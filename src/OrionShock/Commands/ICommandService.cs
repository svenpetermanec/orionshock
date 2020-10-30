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
        void Deregister(object obj);

        /// <summary>
        ///     Gets a list of commands, optionally matches the specified predicate.
        /// </summary>
        /// <param name="filter">The predicate used to filter the commands.</param>
        /// <returns>A list of commands matching the criteria.</returns>
        IEnumerable<ICommand> GetCommands(Predicate<ICommand> filter = null);

        /// <summary>
        ///     Registers commands defined by the specified object.
        /// </summary>
        /// <param name="obj">The object, which must not be <see langword="null" />.</param>
        void Register(object obj);
    }
}