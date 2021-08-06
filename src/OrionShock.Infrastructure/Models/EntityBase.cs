using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrionShock.Infrastructure.Models
{
    /// <summary>
    /// Represents the base class for a table entity.
    /// </summary>
    public abstract class ModelBase
    {
        public Guid Id { get; set; }
    }
}
