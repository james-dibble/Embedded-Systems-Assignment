// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HandsetRental.cs" company="ESD">
//    Copyright 2013
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace EmbeddedSystems.DomainModel
{
    using System;

    /// <summary>
    /// An object that represents an <see cref="ICustomer"/> taking out an <see cref="IHandset"/>.
    /// </summary>
    public class HandsetRental : UniqueObject<int>, IHandsetRental
    {
        /// <summary>
        /// Gets or sets the <see cref="ICustomer"/> that has rented an <see cref="IHandset"/>.
        /// </summary>
        public virtual ICustomer Customer { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="IHandset"/> that the <see cref="ICustomer"/> has rented.
        /// </summary>
        public virtual IHandset Handset { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="System.DateTime"/> that this <see cref="IHandsetRental"/> was conducted.
        /// </summary>
        public DateTime WhenRentedOut { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="System.DateTime"/> that this <see cref="IHandsetRental"/> expires.
        /// </summary>
        public DateTime RentalExpires { get; set; }

        /// <summary>
        /// Gets or sets the identification code the <see cref="ICustomer"/> must use to access the <see cref="IHandset"/>.
        /// </summary>
        public int Pin { get; set; }
    }
}