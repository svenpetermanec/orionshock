using OrionShock.Core.Abstractions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrionShock.Core.Abstractions.Services
{
    /// <summary>
    ///     Defines a contract that describes a warp service.
    /// </summary>
    public interface IWarpService
    {
        /// <summary>
        ///     Creates a warp.
        /// </summary>
        /// <param name="warp">The warp.</param>
        void CreateWarp(IWarp warp);

        /// <summary>
        ///     Removes a warp.
        /// </summary>
        /// <param name="warp">The warp.</param>
        void RemoveWarp(IWarp warp);

        /// <summary>
        /// Gets the warp at the given coordinates.
        /// </summary>
        /// <param name="tileX">The X coordinate.</param>
        /// <param name="tileY">The Y coordinate.</param>
        /// <returns>The warp at the specified coordinates.</returns>
        IWarp Get(int tileX, int tileY);

        /// <summary>
        /// Gets the warp with the given name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>The warp with the given name.</returns>
        IWarp Get(string name);
    }
}
