using Orion.Core;

namespace OrionShock.Configuration {
    /// <summary>
    ///     Describes a configuration service. Facilitates reading and writing configuration files.
    /// </summary>
    /// <typeparam name="TConfiguration">The type of configuration.</typeparam>
    [Service(ServiceScope.Transient)]
    public interface IConfigurationService<out TConfiguration>
        where TConfiguration : new()
    {
        /// <summary>
        ///     Gets the underlying configuration file.
        /// </summary>
        TConfiguration Configuration { get; }

        /// <summary>
        ///     Reads the configuration from the specified file.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        void Read(string path);

        /// <summary>
        ///     Writes the underlying configuration to the specified file.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        void Write(string path);
    }
}