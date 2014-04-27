// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HandsetRental.cs" company="ESD">
//    Copyright 2013
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace EmbeddedSystems.DomainModel
{
    using System;

    /// <summary>
    /// An object that represents an <see cref="Customer"/> taking out an <see cref="Handset"/>.
    /// </summary>
    public class HandsetRental : UniqueObject<int>
    {
        /// <summary>
        /// Gets or sets the <see cref="Customer"/> that has rented an <see cref="Handset"/>.
        /// </summary>
        public virtual Customer Customer { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Handset"/> that the <see cref="Customer"/> has rented.
        /// </summary>
        public virtual Handset Handset { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="System.DateTime"/> that this <see cref="HandsetRental"/> was conducted.
        /// </summary>
        public DateTime WhenRentedOut { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="System.DateTime"/> that this <see cref="HandsetRental"/> expires.
        /// </summary>
        public DateTime RentalExpires { get; set; }

        /// <summary>
        /// Gets or sets the identification code the <see cref="Customer"/> must use to access the <see cref="Handset"/>.
        /// </summary>
        public int Pin { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the <see cref="Handset"/> that is
        /// <see cref="HandsetRental"/> represents. DO NOT USE.
        /// </summary>
        public int HandsetId { get; set; }
    }
}