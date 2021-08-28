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

        public string Name { get; set; }

        public int TileX { get; set; }

        public int TileY { get; set; }

        public static OrionShockWarp FromModel(Warp warpModel) => new(warpModel.Name, warpModel.TileX, warpModel.TileY);
    }
}
