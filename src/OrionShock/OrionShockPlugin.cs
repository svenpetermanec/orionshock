using Orion.Core;
using Serilog;

namespace OrionShock {
    /// <summary>
    ///     Represents the main entry point for the `OrionShock` plugin.
    /// </summary>
    [Plugin("OrionShock", Author = "ivanbiljan")]
    public sealed class OrionShockPlugin : OrionPlugin {
        public OrionShockPlugin(IServer server, ILogger log) : base(server, log) {
        }
    }
}