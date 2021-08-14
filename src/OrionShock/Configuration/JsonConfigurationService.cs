using System.IO;
using System.Text.Json;
using Orion.Core;
using OrionShock.Core.Abstractions.Services;

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
        private static readonly JsonSerializerOptions SerializerOptions = new()
        {
            AllowTrailingCommas = true,
            WriteIndented = true
        };

        /// <inheritdoc />
        public TConfiguration Configuration { get; private set; } = new TConfiguration();

        /// <inheritdoc />
        public void Read(string path)
        {
            if (File.Exists(path))
            {
                Configuration = JsonSerializer.Deserialize<TConfiguration>(File.ReadAllText(path));
                return;
            }

            Configuration = new TConfiguration();
            Write(path);
        }

        /// <inheritdoc />
        public void Write(string path)
        {
            File.WriteAllText(path, JsonSerializer.Serialize(Configuration, SerializerOptions));
        }
    }
}