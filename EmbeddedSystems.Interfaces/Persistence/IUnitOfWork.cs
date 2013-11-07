// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUnitOfWork.cs" company="ESD">
//    Copyright 2013
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace EmbeddedSystems.Persistence
{
    using System.Data.Entity;

    /// <summary>
    /// Implementing classes define a class to store a database context to be injected into services so they all shared
    /// the same data resource.
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Gets the active <see cref="DbContext"/> for this <see cref="IUnitOfWork"/>.
        /// </summary>
        DbContext CurrentContext { get; }

        /// <summary>
        /// Save call changes that have been made to the context.
        /// </summary>
        void Commit();

        /// <summary>
        /// Retrieve an instance of <see cref="IRepository"/> to access the persistence layer.
        /// </summary>
        /// <typeparam name="T">The type of <see cref="IRepository"/> to create.</typeparam>
        /// <returns>An instance of <see cref="IRepository"/> to access the persistence layer.</returns>
        IRepository<T> GetRepository<T>() where T : class;
    }
}