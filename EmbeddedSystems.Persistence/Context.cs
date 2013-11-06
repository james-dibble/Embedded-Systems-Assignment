// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Context.cs" company="ESD">
//    Copyright 2013
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace EmbeddedSystems.Persistence
{
    using System.Data.Entity;

    using EmbeddedSystems.DomainModel;

    /// <summary>
    /// The persistence context for the solution.
    /// </summary>
    public class Context : DbContext
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="Context"/> class.
        /// </summary>
        public Context() : base("ESDConnection")
        {
        }

        /// <summary>
        /// Gets or sets the <see cref="IAudioFile"/> set.
        /// </summary>
        public DbSet<AudioFile> AudioFiles { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="ICustomer"/> set.
        /// </summary>
        public DbSet<Customer> Customers { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="IExhibit"/> set.
        /// </summary>
        public DbSet<Exhibit> Exhibits { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="IHandset"/> set.
        /// </summary>
        public DbSet<Handset> Handsets { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="IHandsetRental"/> set.
        /// </summary>
        public DbSet<HandsetRental> HandsetRentals { get; set; }
        
        /// <summary>
        /// Gets or sets the <see cref="IKnowledgeLevel"/> set.
        /// </summary>
        public DbSet<KnowledgeLevel> KnowledgeLevels { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="ILanguage"/> set.
        /// </summary>
        public DbSet<Language> Languages { get; set; }

        /// <summary>
        /// This method is called when the model for a derived context has been initialized, but
        ///             before the model has been locked down and used to initialize the context.  The default
        ///             implementation of this method does nothing, but it can be overridden in a derived class
        ///             such that the model can be further configured before it is locked down.
        /// </summary>
        /// <remarks>
        /// Typically, this method is called only once when the first instance of a derived context
        ///             is created.  The model for that context is then cached and is for all further instances of
        ///             the context in the app domain.  This caching can be disabled by setting the ModelCaching
        ///             property on the given ModelBuilder, but note that this can seriously degrade performance.
        ///             More control over caching is provided through use of the DBModelBuilder and DBContextFactory
        ///             classes directly.
        /// </remarks>
        /// <param name="modelBuilder">The builder that defines the model for the context being created. </param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AudioFile>().HasKey(entity => new
                {
                    entity.ExhibitId, 
                    entity.KnowledgeLevelId, 
                    entity.LanguageId
                });
        }
    }
}