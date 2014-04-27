// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Handset.cs" company="ESD">
//    Copyright 2013
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EmbeddedSystems.DomainModel
{
    using System.Collections.Generic;

    /// <summary>
    /// An object that stores information about a <see cref="Handset"/>.
    /// </summary>
    public class Handset : UniqueObject<int>
    {
        /// <summary>
        /// Gets or sets the number of this <see cref="Handset"/>.
        /// </summary>
        public string HandsetNumber { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="HandsetRental"/>s this <see cref="Handset"/> has had.
        /// </summary>
        public virtual ICollection<HandsetRental> Rentals { get; set; }
    }
}