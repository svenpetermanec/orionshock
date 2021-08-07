﻿using OrionShock.Core.Abstractions.Models;
using OrionShock.Infrastructure.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrionShock.Infrastructure.EntityFrameworkCore.Models
{
    public sealed class Warp : EntityBase
    {
        private Warp()
        {
        }

        public string Name { get; set; }

        public int TileX { get; set; }

        public int TileY { get; set; }
    }
}
