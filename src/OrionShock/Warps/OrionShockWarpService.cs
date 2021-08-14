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
    [Binding(nameof(OrionShockWarpService), Author = "ivanbiljan")]
    internal sealed class OrionShockWarpService : IWarpService
    {
        private readonly IMapper _mapper;
        private readonly IServer _server;
        private readonly IWarpRepository _warpRepository;

        public OrionShockWarpService(IServer server, IWarpRepository warpRepository, IMapper mapper)
        {
            _server = server ?? throw new ArgumentNullException(nameof(server));
            _warpRepository = warpRepository ?? throw new ArgumentNullException(nameof(warpRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public void CreateWarp(string name, int tileX, int tileY)
        {
            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            if (tileX < 0 || tileX > _server.World.Width)
            {
                throw new ArgumentException(null, nameof(tileX));
            }

            if (tileY < 0 || tileY > _server.World.Height)
            {
                throw new ArgumentException(null, nameof(tileY));
            }

            var warp = new OrionShockWarp(name, tileX, tileY);
            _warpRepository.Add(_mapper.Map<Warp>(warp));
        }

        public IWarp Get(int tileX, int tileY)
        {
            if (tileX < 0 || tileX > _server.World.Width)
            {
                throw new ArgumentException(null, nameof(tileX));
            }

            if (tileY < 0 || tileY > _server.World.Height)
            {
                throw new ArgumentException(null, nameof(tileY));
            }

            return _mapper.Map<OrionShockWarp>(_warpRepository.GetWarpByPosition(tileX, tileY));
        }

        public IWarp Get(string name)
        {
            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            return _mapper.Map<OrionShockWarp>(_warpRepository.GetWarpByName(name));
        }

        public void RemoveWarp(IWarp warp)
        {
            if (warp is null)
            {
                throw new ArgumentNullException(nameof(warp));
            }

            _warpRepository.Delete(_mapper.Map<Warp>((OrionShockWarp)warp));
        }
    }
}