using System.IO;
using Newtonsoft.Json;
using Orion.Core;

namespace OrionShock.Configuration
{
    /// <summary>
    ///     Represents a JSON-based configuration service.
    /// </summary>
    /// <typeparam name="TConfiguration">The type of configuration this instance encapsulates.</typeparam>
    [Binding("JSON Configuration Service", Author = "ivanbiljan", Priority = BindingPriority.Normal)]
    internal sealed class JsonConfigurationService<TConfiguration> : IConfigurationService<TConfiguration>
        where TConfiguration : new()
    {
        /// <inheritdoc />
        public TConfiguration Configuration { get; private set; } = new TConfiguration();

        /// <inheritdoc />
        public void Read(string path)
        {
            if (File.Exists(path))
            {
                Configuration = JsonConvert.DeserializeObject<TConfiguration>(File.ReadAllText(path));
                return;
            }

            Configuration = new TConfiguration();
            Write(path);
        }

        /// <inheritdoc />
        public void Write(string path)
        {
            File.WriteAllText(path, JsonConvert.SerializeObject(Configuration, Formatting.Indented));
        }
    }
}