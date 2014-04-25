// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IExhibitService.cs" company="ESD">
//    Copyright 2013
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace EmbeddedSystems.ServiceLayer
{
    using System.Collections.Generic;
    using EmbeddedSystems.DomainModel;

    /// <summary>
    /// Implementing classes define methods for interacting with <see cref="Exhibit"/>s.
    /// </summary>
    public interface IExhibitService
    {
        /// <summary>
        /// Retrieve an <see cref="Exhibit"/>.
        /// </summary>
        /// <param name="exhibitId">The unique identifier of the <see cref="Exhibit"/>.</param>
        /// <returns>The <see cref="Exhibit"/> that matches the given <paramref name="exhibitId"/>.</returns>
        Exhibit GetExhibit(int exhibitId);

        /// <summary>
        /// Retrieve an <see cref="Exhibit"/>.
        /// </summary>
        /// <param name="handsetKey">The key number on the handset for this <see cref="Exhibit"/>.</param>
        /// <returns>The <see cref="Exhibit"/> with the given <paramref name="handsetKey"/>.</returns>
        Exhibit GetExhibitByHandsetKey(int handsetKey);

        /// <summary>
        /// Retrieve all known <see cref="Exhibit"/>s.
        /// </summary>
        /// <returns>All known <see cref="Exhibit"/>s.</returns>
        IEnumerable<Exhibit> GetAll();

        /// <summary>
        /// Build and persist a new <see cref="Exhibit"/>.
        /// </summary>
        /// <param name="exhibit">A new <see cref="Exhibit"/></param>
        /// <returns>The persisted <see cref="Exhibit"/>.</returns>
        Exhibit CreateExhibit(Exhibit exhibit);
    }
}