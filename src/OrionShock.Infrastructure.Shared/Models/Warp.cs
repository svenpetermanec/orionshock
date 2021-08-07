using OrionShock.Core.Abstractions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrionShock.Infrastructure.Models
{   
    public sealed class Warp : EntityBase, IWarp
    {
        public string Name { get; set; }

        public int TileX { get; set; }

        public int TileY { get; set; }
    }
}
