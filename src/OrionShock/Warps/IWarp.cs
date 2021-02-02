namespace OrionShock.Warps
{
    /// <summary>
    ///     Describes a warp.
    /// </summary>
    public interface IWarp
    {
        /// <summary>
        ///     Gets the name.
        /// </summary>
        string Name { get; }

        /// <summary>
        ///     Gets the X coordinate.
        /// </summary>
        int TileX { get; }

        /// <summary>
        ///     Gets the Y coordinate.
        /// </summary>
        int TileY { get; }
    }
}