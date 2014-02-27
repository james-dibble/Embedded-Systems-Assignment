// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IHandsetService.cs" company="ESD">
//    Copyright 2013
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace EmbeddedSystems.ServiceLayer
{
    using System;
    using System.Collections.Generic;
    using EmbeddedSystems.DomainModel;

    /// <summary>
    /// Implementing classes define methods for interacting with <see cref="Handset"/>s.
    /// </summary>
    public interface IHandsetService
    {
        /// <summary>
        /// Get the <see cref="HandsetRental"/>s for a given <see cref="Handset"/>.
        /// </summary>
        /// <param name="handsetNumber">The unique identifier of the <see cref="Handset"/>.</param>
        /// <returns>A collection of the <see cref="HandsetRental"/>s for the given <see cref="Handset"/>.</returns>
        IEnumerable<HandsetRental> GetRentalsOfHandset(string handsetNumber);

        /// <summary>
        /// Set a <see cref="Handset"/> to be rented.
        /// </summary>
        /// <param name="customer">The customer renting the handset.</param>
        /// <returns>A new handset rental.</returns>
        HandsetRental RentHandset(Customer customer);

        /// <summary>
        /// Get the available handsets.
        /// </summary>
        /// <param name="dateAvailableFrom">The DateTime you want to check.</param>
        /// <returns>A collection of available handsets.</returns>
        IEnumerable<Handset> GetAvailableHandsets(DateTime dateAvailableFrom);

        /// <summary>
        /// Get all of the handsets for a given customer.
        /// </summary>
        /// <param name="customerId">The id of the customer.</param>
        /// <returns>A collection containing all of the rentals belonging to a customer.</returns>
        IEnumerable<HandsetRental> GetAllRentalsForCustomer(int customerId);

        /// <summary>
        /// Get all of the rentals that have occurred.
        /// </summary>
        /// <returns>All of the rentals.</returns>
        IEnumerable<HandsetRental> GetAllRentals();

        /// <summary>
        /// Get all of the handsets.
        /// </summary>
        /// <returns>Return a collection of all the handsets.</returns>
        IEnumerable<Handset> GetAllHandsets();

        /// <summary>
        /// Get a handset by a given id.
        /// </summary>
        /// <param name="handsetId">The id of the requested handset.</param>
        /// <returns>The handset.</returns>
        Handset GetHandset(int handsetId);

        HandsetRental GetCurrentRentalForHandset(int handsetId);

        void ExpireRental(HandsetRental rental);

        Handset CreateHandset(string handsetNumber);
    }
}