using AutoMapper;
using Orion.Core;
using OrionShock.Core.Abstractions.Models;
using OrionShock.Core.Abstractions.Services;
using OrionShock.Infrastructure.Shared.Models;
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
        private readonly IMapper _mapper;

        public OrionShockWarpService(IWarpRepository warpRepository, IMapper mapper)
        {
            _warpRepository = warpRepository ?? throw new ArgumentNullException(nameof(warpRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public void CreateWarp(IWarp warp)
        {
            if (warp is null)
            {
                throw new ArgumentNullException(nameof(warp));
            }

            _warpRepository.Add(_mapper.Map<Warp>(warp));
        }

        public IWarp Get(int tileX, int tileY)
        {
            throw new NotImplementedException();
        }

        public IWarp Get(string name) => OrionShockWarp.FromModel(_warpRepository.GetWarpByName(name));

        public void RemoveWarp(IWarp warp)
        {
            throw new NotImplementedException();
        }
    }
}
