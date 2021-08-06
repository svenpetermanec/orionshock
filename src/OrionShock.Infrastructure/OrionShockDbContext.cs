using Microsoft.EntityFrameworkCore;
using OrionShock.Infrastructure.Models;
using System;

namespace OrionShock.Infrastructure
{
    public sealed class OrionShockDbContext : DbContext
    {
        public OrionShockDbContext(DbContextOptions<OrionShockDbContext> options) : base(options)
        {

        }

        public DbSet<Warp> Warps { get; set; }
    }
}
