// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Configuration.cs" company="ESD">
//    Copyright 2013
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace EmbeddedSystems.Persistence.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Context>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.ContextKey = "EmbeddedSystems.Persistence.Context";
        }

        protected override void Seed(Context context)
        {
        }
    }
}
