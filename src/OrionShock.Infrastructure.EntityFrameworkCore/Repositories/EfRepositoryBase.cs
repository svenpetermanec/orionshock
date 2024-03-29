﻿using OrionShock.Infrastructure.EntityFrameworkCore.Persistence;
using OrionShock.Infrastructure.Shared.Models;
using OrionShock.Infrastructure.Shared.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrionShock.Infrastructure.EntityFrameworkCore.Repositories
{
    /// <summary>
    /// Represents the base class for an Entity Framework repository that manages entities of type <typeparamref name="T"/>.
    /// </summary>
    /// <remarks>CRUD operations provided by this class will not persist unless the</remarks>
    /// <typeparam name="T">The type of entity this repository manages.</typeparam>
    public class EfRepositoryBase<T> : IRepository<T> where T : EntityBase
    {
        public EfRepositoryBase(OrionShockDbContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        protected OrionShockDbContext Context { get; }

        public void Add(T entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            Context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            Context.Set<T>().Remove(entity);
        }

        public T Get(int id)
        {
            if (id < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id));
            }

            return Context.Set<T>().Find(id);
        }

        public void Update(T entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            Context.Set<T>().Update(entity);
        }
    }
}