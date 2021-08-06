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
    }
}
