using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrionShock.Infrastructure.Repositories
{
    public sealed class UnitOfWork
    {
        private readonly OrionShockDbContext _context;

        public UnitOfWork(OrionShockDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
