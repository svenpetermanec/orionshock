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
        private readonly IMapper _mapper;
        private readonly IServer _server;
        private readonly IWarpRepository _warpRepository;

        public OrionShockWarpService(IServer server, IWarpRepository warpRepository, IMapper mapper)
        {
            _server = server ?? throw new ArgumentNullException(nameof(server));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _warpRepository = warpRepository ?? throw new ArgumentNullException(nameof(warpRepository));
        }

        public void CreateWarp(string name, int tileX, int tileY)
        {
            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            if (tileX < 0 || tileX > _server.World.Width)
            {
                throw new ArgumentException(nameof(tileX));
            }

            if (tileY < 0 || tileY > _server.World.Height)
            {
                throw new ArgumentException(nameof(tileY));
            }

            var warp = new OrionShockWarp(name, tileX, tileY);
            _warpRepository.Add(_mapper.Map<Warp>(warp));
        }

        public IWarp Get(int tileX, int tileY) => _mapper.Map<OrionShockWarp>(_warpRepository.GetWarpByPosition(tileX, tileY));

        public IWarp Get(string name) => _mapper.Map<OrionShockWarp>(_warpRepository.GetWarpByName(name));

        public void RemoveWarp(IWarp warp)
        {
            _warpRepository.Delete(_mapper.Map<Warp>((OrionShockWarp)warp));
        }
    }
}