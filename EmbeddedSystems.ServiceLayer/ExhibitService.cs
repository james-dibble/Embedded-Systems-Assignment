// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExhibitService.cs" company="ESD">
//    Copyright 2013
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace EmbeddedSystems.ServiceLayer
{
    using System.Collections.Generic;

    using EmbeddedSystems.DomainModel;
    using EmbeddedSystems.Persistence;

    /// <summary>
    /// A class for interacting with <see cref="Exhibit"/>s.
    /// </summary>
    public class ExhibitService : IExhibitService
    {
        private readonly IUnitOfWork _persistence;

        /// <summary>
        /// Initialises a new instance of the <see cref="ExhibitService"/> class.
        /// </summary>
        /// <param name="persistence">The current persistence context.</param>
        public ExhibitService(IUnitOfWork persistence)
        {
            this._persistence = persistence;
        }

        /// <summary>
        /// Retrieve an <see cref="Exhibit"/>.
        /// </summary>
        /// <param name="exhibitId">The unique identifier of the <see cref="Exhibit"/>.</param>
        /// <returns>The <see cref="Exhibit"/> that matches the given <paramref name="exhibitId"/>.</returns>
        public Exhibit GetExhibit(int exhibitId)
        {
            var exhibit = this._persistence.GetRepository<Exhibit>().Single(e => e.Id == exhibitId);

            return exhibit;
        }

        /// <summary>
        /// Retrieve an <see cref="Exhibit"/>.
        /// </summary>
        /// <param name="handsetKey">The key number on the handset for this <see cref="Exhibit"/>.</param>
        /// <returns>The <see cref="Exhibit"/> with the given <paramref name="handsetKey"/>.</returns>
        public Exhibit GetExhibitByHandsetKey(int handsetKey)
        {
            var exhibit = this._persistence.GetRepository<Exhibit>().Single(e => e.HandsetKey == handsetKey);

            return exhibit;
        }

        /// <summary>
        /// Retrieve all known <see cref="Exhibit"/>s.
        /// </summary>
        /// <returns>All known <see cref="Exhibit"/>s.</returns>
        public IEnumerable<Exhibit> GetAll()
        {
            return this._persistence.GetRepository<Exhibit>().GetAll();
        }

        /// <summary>
        /// Build and persist a new <see cref="Exhibit"/>.
        /// </summary>
        /// <param name="exhibit">A new <see cref="Exhibit"/></param>
        /// <returns>The persisted <see cref="Exhibit"/>.</returns>
        public Exhibit CreateExhibit(Exhibit exhibit)
        {
            this._persistence.GetRepository<Exhibit>().Add(exhibit);
            this._persistence.Commit();

            return exhibit;
        }
    }
}