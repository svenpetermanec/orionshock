using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrionShock.Infrastructure.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrionShock.Infrastructure.EntityFrameworkCore.Persistence.Configurations
{
    public sealed class WarpConfiguration : IEntityTypeConfiguration<Warp>
    {
        public void Configure(EntityTypeBuilder<WarpConfiguration> builder)
        {
        }
    }
}
