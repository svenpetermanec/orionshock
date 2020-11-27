namespace OrionShock.Warps {

    /// <summary>
    /// Provides a warp service.
    /// </summary>
    public interface IWarpService {

        /// <summary>
        /// Creates a warp.
        /// </summary>
        /// <param name="warp">The warp.</param>
        void CreateWarp(IWarp warp);

        /// <summary>
        /// Removes a warp.
        /// </summary>
        /// <param name="warp">The warp.</param>
        void RemoveWarp(IWarp warp);
    }
}