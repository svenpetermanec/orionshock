﻿using Orion.Core;
using OrionShock.Core.Abstractions.Models;
using OrionShock.Core.Abstractions.Services;
using OrionShock.Infrastructure.Shared.Repositories;
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
        private readonly IWarpRepository _warpRepository;

        public OrionShockWarpService(IWarpRepository warpRepository)
        {
            _warpRepository = warpRepository ?? throw new ArgumentNullException(nameof(warpRepository));
        }

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
