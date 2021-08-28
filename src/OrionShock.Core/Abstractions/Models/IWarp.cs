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
        ///     Gets or sets the name.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        ///     Gets or sets the X coordinate.
        /// </summary>
        int TileX { get; set; }

        /// <summary>
        ///     Gets or sets the Y coordinate.
        /// </summary>
        int TileY { get; set; }
    }
}
