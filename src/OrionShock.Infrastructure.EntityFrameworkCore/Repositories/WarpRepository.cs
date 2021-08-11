using OrionShock.Infrastructure.EntityFrameworkCore.Persistence;
using OrionShock.Infrastructure.Shared.Models;
using OrionShock.Infrastructure.Shared.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrionShock.Infrastructure.EntityFrameworkCore.Repositories
{
    internal sealed class WarpRepository : EfRepositoryBase<Warp>, IWarpRepository
    {
        public WarpRepository(OrionShockDbContext context) : base(context)
        {
        }

        public Warp GetWarpByName(string name) => Context.Warps!.FirstOrDefault(w => w.Name == name);

        public Warp GetWarpByPosition(int tileX, int tileY) => Context.Warps!.FirstOrDefault(w => w.TileX == tileX && w.TileY == tileY);
    }
}
