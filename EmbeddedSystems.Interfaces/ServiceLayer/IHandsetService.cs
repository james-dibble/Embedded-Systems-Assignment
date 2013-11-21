// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IHandsetService.cs" company="ESD">
//    Copyright 2013
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace EmbeddedSystems.ServiceLayer
{
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
        IEnumerable<HandsetRental> GetRentalsOfHandset(int handsetNumber);
    }
}