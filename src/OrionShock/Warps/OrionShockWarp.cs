using OrionShock.DataLayer;

namespace OrionShock.Warps {

    /// <summary>
    /// Represents an OrionShock warp.
    /// </summary>
    [Table("Warps")]
    internal sealed class OrionShockWarp : DataModelBase, IWarp {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrionShockWarp"/> class.
        /// </summary>
        /// <param name="worldId">The world ID.</param>
        /// <param name="name">The name.</param>
        /// <param name="tileX">The X coordinate.</param>
        /// <param name="tileY">The Y coordinate.</param>
        public OrionShockWarp(long worldId, string name, int tileX, int tileY) {
            WorldId = worldId;
            Name = name;
            TileX = tileX;
            TileY = tileY;
        }

        /// <summary>
        /// Gets the world ID.
        /// </summary>
        [Column("WorldId")]
        [PrimaryKey("PK")]
        public long WorldId { get; init; }

        /// <inheritdoc/>
        [Column("Name", IsUnique = true)]
        [PrimaryKey("PK")]
        public string Name { get; init; }

        /// <inheritdoc/>
        [Column("X")]
        public int TileX { get; init; }

        /// <inheritdoc/>
        [Column("Y")]
        public int TileY { get; init; }
    }
}