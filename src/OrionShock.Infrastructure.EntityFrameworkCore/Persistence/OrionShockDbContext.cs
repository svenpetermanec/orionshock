using Microsoft.EntityFrameworkCore;
using OrionShock.Infrastructure.Shared.Models;
using System;

namespace OrionShock.Infrastructure.EntityFrameworkCore
{
    public sealed class OrionShockDbContext : DbContext
    {
        public OrionShockDbContext(DbContextOptions<OrionShockDbContext> options) : base(options)
        {

        }

        public DbSet<Warp> Warps { get; set; }
    }
}
