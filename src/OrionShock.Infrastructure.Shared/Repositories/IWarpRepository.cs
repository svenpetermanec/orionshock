using OrionShock.Core.Abstractions.Models;
using OrionShock.Infrastructure.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrionShock.Infrastructure.Shared.Repositories
{
    /// <summary>
    /// Defines a contract that describes a <see cref="Warp"/> repository.
    /// </summary>
    public interface IWarpRepository : IRepository<Warp>
    {
        Warp GetWarpByName(string name);
    }
}
