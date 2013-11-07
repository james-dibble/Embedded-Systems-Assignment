// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPersistenceContext.cs" company="ESD">
//    Copyright 2013
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace EmbeddedSystems.Persistence
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using EmbeddedSystems.DomainModel;

    /// <summary>
    /// Implementing classes define methods of accessing the persistence layer.
    /// </summary>
    public interface IPersistenceContext : IObjectContextAdapter
    {
        /// <summary>
        /// Gets or sets the <see cref="AudioFile"/> set.
        /// </summary>
        IDbSet<AudioFile> AudioFiles { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Customer"/> set.
        /// </summary>
        IDbSet<Customer> Customers { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Exhibit"/> set.
        /// </summary>
        IDbSet<Exhibit> Exhibits { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Handset"/> set.
        /// </summary>
        IDbSet<Handset> Handsets { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="HandsetRental"/> set.
        /// </summary>
        IDbSet<HandsetRental> HandsetRentals { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="KnowledgeLevel"/> set.
        /// </summary>
        IDbSet<KnowledgeLevel> KnowledgeLevels { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Language"/> set.
        /// </summary>
        IDbSet<Language> Languages { get; set; } 
    }
}