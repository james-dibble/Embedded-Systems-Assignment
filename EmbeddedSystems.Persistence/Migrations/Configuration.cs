// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Configuration.cs" company="ESD">
//    Copyright 2013
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace EmbeddedSystems.Persistence.Migrations
{
    using System.Data.Entity.Migrations;

    /// <summary>
    /// The configuration for Entity Framework Migrations.
    /// </summary>
    internal sealed class Configuration : DbMigrationsConfiguration<Context>
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="Configuration"/> class.
        /// </summary>
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = false;
            this.ContextKey = "EmbeddedSystems.Persistence.Context";
        }

        /// <summary>
        /// Runs after upgrading to the latest migration to allow seed data to be updated.
        /// </summary>
        /// <param name="context">Context to be used for updating seed data. </param>
        protected override void Seed(Context context)
        {
        }
    }
}
