using Orion.Core;
using OrionShock.Core.Abstractions.Models;
using OrionShock.Core.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrionShock.Warps
{
    [Binding("OrionShockWarpService", Author = "ivanbiljan")]
    internal sealed class OrionShockWarpService : IWarpService
    {
        public void CreateWarp(IWarp warp)
        {
            throw new NotImplementedException();
        }

        public void RemoveWarp(IWarp warp)
        {
            throw new NotImplementedException();
        }
    }
}
