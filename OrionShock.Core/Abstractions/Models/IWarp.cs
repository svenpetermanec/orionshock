using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrionShock.Core.Abstractions.Models
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
