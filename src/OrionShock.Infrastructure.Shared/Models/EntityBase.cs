using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrionShock.Infrastructure.Shared.Models
{
    /// <summary>
    /// Represents the base class for a table entity.
    /// </summary>
    public abstract class EntityBase
    {
        public Guid Id { get; set; }
    }
}
