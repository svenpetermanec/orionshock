using System;
using OrionShock.DataLayer;

namespace OrionShock.Warps
{
    internal sealed class OrionShockWarpService : IWarpService
    {
        private readonly IRepository<IWarp> _warpRepository;

        /// <summary>
        ///     Initializes a new instance of the <see cref="OrionShockWarpService" /> class.
        /// </summary>
        /// <param name="warpRepository">The warp repository instance.</param>
        public OrionShockWarpService(IRepository<IWarp> warpRepository)
        {
            _warpRepository = warpRepository ?? throw new ArgumentNullException(nameof(warpRepository));
        }


        /// <inheritdoc />
        public void CreateWarp(IWarp warp)
        {
            _warpRepository.Create(warp);
        }

        /// <inheritdoc />
        public void RemoveWarp(IWarp warp)
        {
            _warpRepository.Delete(warp);
        }
    }
}