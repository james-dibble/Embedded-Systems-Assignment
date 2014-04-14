// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IExhibitService.cs" company="ESD">
//    Copyright 2013
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace EmbeddedSystems.ServiceLayer
{
    using EmbeddedSystems.DomainModel;
using System.Collections.Generic;

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

        IEnumerable<Exhibit> GetAll();

        Exhibit CreateExhibit(Exhibit exhibit);
    }
}