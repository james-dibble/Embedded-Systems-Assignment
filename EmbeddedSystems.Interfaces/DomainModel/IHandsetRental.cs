// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IHandsetRental.cs" company="ESD">
//    Copyright 2013
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace EmbeddedSystems.DomainModel
{
    using System;

    /// <summary>
    /// An object that represents an <see cref="ICustomer"/> taking out an <see cref="IHandset"/>.
    /// </summary>
    public interface IHandsetRental : IUniqueObject<int>
    {
        /// <summary>
        /// Gets the <see cref="ICustomer"/> that has rented an <see cref="IHandset"/>.
        /// </summary>
        ICustomer Customer { get; }

        /// <summary>
        /// Gets the <see cref="IHandset"/> that the <see cref="ICustomer"/> has rented.
        /// </summary>
        IHandset Handset { get; }

        /// <summary>
        /// Gets the <see cref="System.DateTime"/> that this <see cref="IHandsetRental"/> was conducted.
        /// </summary>
        DateTime WhenRentedOut { get; }

        /// <summary>
        /// Gets the <see cref="System.DateTime"/> that this <see cref="IHandsetRental"/> expires.
        /// </summary>
        DateTime RentalExpires { get; }

        /// <summary>
        /// Gets the identification code the <see cref="ICustomer"/> must use to access the <see cref="IHandset"/>.
        /// </summary>
        int Pin { get; }
    }
}