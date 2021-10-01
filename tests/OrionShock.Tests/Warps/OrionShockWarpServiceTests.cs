using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Moq;
using Orion.Core;
using OrionShock.Infrastructure.Shared.Repositories;
using OrionShock.Warps;
using Xunit;

namespace OrionShock.Tests.Warps
{
    public sealed class OrionShockWarpServiceTests
    {
        [Fact]
        public void Ctor_NullServer_ThrowsArgumentNullException()
        {
            var warpRepository = Mock.Of<IWarpRepository>();
            var mapper = Mock.Of<IMapper>();

            Assert.Throws<ArgumentNullException>(() => new OrionShockWarpService(null, warpRepository, mapper));
        }

        [Fact]
        public void Ctor_NullRepository_ThrowsArgumentNullException()
        {
            var server = Mock.Of<IServer>();
            var mapper = Mock.Of<IMapper>();

            Assert.Throws<ArgumentNullException>(() => new OrionShockWarpService(server, null, mapper));
        }

        [Fact]
        public void Ctor_NullMapper_ThrowsArgumentNullException()
        {
            var server = Mock.Of<IServer>();
            var warpRepository = Mock.Of<IWarpRepository>();

            Assert.Throws<ArgumentNullException>(() => new OrionShockWarpService(server, warpRepository, null));
        }

        [Fact]
        public void CreateWarp_NullName_ThrowsArgumentNullException()
        {
            var server = Mock.Of<IServer>();
            var warpRepository = Mock.Of<IWarpRepository>();
            var mapper = Mock.Of<IMapper>();
            var warpService = new OrionShockWarpService(server, warpRepository, mapper);

            Assert.Throws<ArgumentNullException>(() => warpService.CreateWarp(null, 0, 0));
        }

        [Fact]
        public void CreateWarp_InvalidTileX_ThrowsArgumentNullException()
        {
            var server = Mock.Of<IServer>();
            var warpRepository = Mock.Of<IWarpRepository>();
            var mapper = Mock.Of<IMapper>();
            var warpService = new OrionShockWarpService(server, warpRepository, mapper);

            Assert.Throws<ArgumentNullException>(() => warpService.CreateWarp("", -1, 0));
        }

        [Fact]
        public void CreateWarp_InvalidTileY_ThrowsArgumentNullException()
        {
            var server = Mock.Of<IServer>();
            var warpRepository = Mock.Of<IWarpRepository>();
            var mapper = Mock.Of<IMapper>();
            var warpService = new OrionShockWarpService(server, warpRepository, mapper);

            Assert.Throws<ArgumentNullException>(() => warpService.CreateWarp("", 0, -1));
        }
    }
}
