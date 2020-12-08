using JetBrains.Annotations;
using Orion.Core;
using OrionShock.Configuration;
using OrionShock.DataLayer;

namespace OrionShock.Warps {
    /// <summary>
    ///     Represents the OrionShock warp repository.
    /// </summary>
    [Binding("OSWarpRepository", Author = "ivanbiljan", Priority = BindingPriority.Low)]
    internal sealed class OrionShockWarpRepository : RepositoryBase<IWarp> {
        /// <summary>
        ///     Initializes a new instance of the <see cref="OrionShockWarpRepository" /> class.
        /// </summary>
        /// <param name="configurationService">The configuration service instance.</param>
        public OrionShockWarpRepository(IConfigurationService<OrionShockConfig> configurationService) : base(
            configurationService) {
        }

        /// <inheritdoc />
        public override void Create([NotNull] IWarp obj) {
        }

        /// <inheritdoc />
        public override void Delete(IWarp obj) {
        }

        /// <inheritdoc />
        public override IWarp Read() {
            return null;
        }

        /// <inheritdoc />
        public override void Update([NotNull] IWarp obj) {
        }
    }
}