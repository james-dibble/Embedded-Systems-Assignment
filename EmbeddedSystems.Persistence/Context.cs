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
    public class Context : DbContext, IPersistenceContext
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="Context"/> class.
        /// </summary>
        public Context() : base("ESDConnection")
        {
            this.Configuration.LazyLoadingEnabled = true;
            this.Configuration.ProxyCreationEnabled = true;
        }

        /// <summary>
        /// Gets or sets the <see cref="AudioFile"/> set.
        /// </summary>
        public IDbSet<AudioFile> AudioFiles { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Customer"/> set.
        /// </summary>
        public IDbSet<Customer> Customers { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Exhibit"/> set.
        /// </summary>
        public IDbSet<Exhibit> Exhibits { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Handset"/> set.
        /// </summary>
        public IDbSet<Handset> Handsets { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="HandsetRental"/> set.
        /// </summary>
        public IDbSet<HandsetRental> HandsetRentals { get; set; }
        
        /// <summary>
        /// Gets or sets the <see cref="KnowledgeLevel"/> set.
        /// </summary>
        public IDbSet<KnowledgeLevel> KnowledgeLevels { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Language"/> set.
        /// </summary>
        public IDbSet<Language> Languages { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Administrator"/> set.
        /// </summary>
        public IDbSet<Administrator> Administrators { get; set; }

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

            modelBuilder.Entity<AudioFile>()
                .HasRequired(a => a.Exhibit)
                .WithMany(e => e.AudioFiles);
            modelBuilder.Entity<AudioFile>().HasRequired(a => a.Language);
            modelBuilder.Entity<AudioFile>().HasRequired(a => a.KnowledgeLevel);

            modelBuilder.Entity<Customer>().HasRequired(c => c.Language);
            modelBuilder.Entity<Customer>().HasRequired(c => c.KnowledgeLevel);

            modelBuilder.Entity<HandsetRental>().HasRequired(hr => hr.Customer);
            modelBuilder.Entity<HandsetRental>().HasRequired(hr => hr.Handset);            
        }
    }
}