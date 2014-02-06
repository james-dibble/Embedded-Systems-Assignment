// --------------------------------------------------------------------------------------------------------------------
// <copyright file="201401301333173_AddColumns.cs" company="ESD">
//    Copyright 2013
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EmbeddedSystems.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    /// <summary>
    /// Add relevant columns to database table.
    /// </summary>
    public partial class AddColumns : DbMigration
    {
        /// <summary>
        /// Create the columns when migration is used.
        /// </summary>
        public override void Up()
        {
            this.AddColumn("Languages", "FlagUrl", c => c.String());
            this.AddColumn("Customers", "Email", c => c.String());
        }

        /// <summary>
        /// Drop the columns if migration is reversed.
        /// </summary>
        public override void Down()
        {
            this.DropColumn("Languages", "FlagUrl");
            this.DropColumn("Customers", "Email");
        }
    }
}
