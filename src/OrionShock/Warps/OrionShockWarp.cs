using OrionShock.Core.Abstractions.Models;
using OrionShock.Infrastructure.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrionShock.Warps
{
    internal sealed class OrionShockWarp : IWarp
    {
        public OrionShockWarp(string name, int tileX, int tileY)
        {
            Name = name;
            TileX = tileX;
            TileY = tileY;
        }

        public string Name { get; }

        public int TileX { get; }

        public int TileY { get; }

        public static OrionShockWarp FromModel(Warp warpModel) => new(warpModel.Name, warpModel.TileX, warpModel.TileY);
    }
}
