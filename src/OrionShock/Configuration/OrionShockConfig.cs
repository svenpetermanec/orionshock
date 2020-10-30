namespace OrionShock.Configuration {
    /// <summary>
    ///     Represents the `OrionShock` configuration file.
    /// </summary>
    public sealed class OrionShockConfig {
        /// <summary>
        ///     Gets or sets the silent command prefix.
        /// </summary>
        public string CommandSilentSpecifier { get; set; } = ".";

        /// <summary>
        ///     Gets or sets the command prefix.
        /// </summary>
        public string CommandSpecifier { get; set; } = "/";
    }
}