using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OrionShock.Infrastructure.EntityFrameworkCore.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrionShock.Infrastructure.EntityFrameworkCore.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddOrionShockDbContext(this IServiceCollection serviceCollection, string connectionString)
        {
            if (serviceCollection is null)
            {
                throw new ArgumentNullException(nameof(serviceCollection));
            }

            if (connectionString is null)
            {
                throw new ArgumentNullException(nameof(connectionString));
            }

            serviceCollection.AddDbContext<OrionShockDbContext>(opts => opts.UseNpgsql(connectionString));
        }
    }
}
