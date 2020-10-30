using System.IO;
using Newtonsoft.Json;
using Orion.Core;

namespace OrionShock.Configuration {
    /// <summary>
    ///     Represents a JSON-based configuration service.
    /// </summary>
    /// <typeparam name="TConfiguration">The type of configuration this instance encapsulates.</typeparam>
    [Binding("JSON Configuration Service", Priority = BindingPriority.Normal)]
    public sealed class JsonConfigurationService<TConfiguration> : IConfigurationService<TConfiguration>
        where TConfiguration : new() {
        public TConfiguration Configuration { get; private set; } = new TConfiguration();

        public void Read(string path) => JsonConvert.SerializeObject(Configuration, Formatting.Indented);

        public void Write(string path) =>
            Configuration = JsonConvert.DeserializeObject<TConfiguration>(File.ReadAllText(path));
    }
}