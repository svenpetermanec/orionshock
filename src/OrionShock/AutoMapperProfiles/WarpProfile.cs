using AutoMapper;
using OrionShock.Infrastructure.Shared.Models;
using OrionShock.Warps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrionShock.AutoMapperProfiles
{
    internal sealed class WarpProfile : Profile
    {
        public WarpProfile()
        {
            CreateMap<Warp, OrionShockWarp>();
        }
    }
}
