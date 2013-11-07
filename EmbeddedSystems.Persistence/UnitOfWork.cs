// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnitOfWork.cs" company="ESD">
//    Copyright 2013
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace EmbeddedSystems.Persistence
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;

    /// <summary>
    /// A class to store a database context to be injected into services so they all shared
    /// the same data resource.
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;
        private readonly IDictionary<Type, IRepository> _repositoryCache;

        /// <summary>
        /// Initialises a new instance of the <see cref="UnitOfWork"/> class.
        /// </summary>
        /// <param name="context">The current database context.</param>
        public UnitOfWork(DbContext context)
        {
            this._context = context;
            this._repositoryCache = new Dictionary<Type, IRepository>();
        }

        /// <summary>
        /// Gets the active <see cref="DbContext"/> for this <see cref="IUnitOfWork"/>.
        /// </summary>
        public DbContext CurrentContext
        {
            get
            {
                return this._context;
            }
        }

        /// <summary>
        /// Save call changes that have been made to the context.
        /// </summary>
        public void Commit()
        {
            this._context.SaveChanges();
        }

        /// <summary>
        /// Retrieve an instance of <see cref="IRepository"/> to access the persistence layer.
        /// </summary>
        /// <typeparam name="T">The type of <see cref="IRepository"/> to create.</typeparam>
        /// <returns>An instance of <see cref="IRepository"/> to access the persistence layer.</returns>
        public IRepository<T> GetRepository<T>() where T : class
        {
            if (this._repositoryCache.ContainsKey(typeof(T)))
            {
                return this._repositoryCache[typeof(T)] as IRepository<T>;
            }

            var repo = new Repository<T>(this);

            this._repositoryCache.Add(typeof(T), repo);

            return repo;
        }
    }
}