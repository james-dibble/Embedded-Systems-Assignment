// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HandsetService.cs" company="ESD">
//    Copyright 2013
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace EmbeddedSystems.ServiceLayer
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    using EmbeddedSystems.DomainModel;
    using EmbeddedSystems.Persistence;

    /// <summary>
    /// A class for interacting with <see cref="Handset"/>s.
    /// </summary>
    public class HandsetService : IHandsetService
    {
        private readonly IUnitOfWork _persistence;

        /// <summary>
        /// Initialises a new instance of the <see cref="HandsetService"/> class.
        /// </summary>
        /// <param name="persistence">The current persistence context.</param>
        public HandsetService(IUnitOfWork persistence)
        {
            this._persistence = persistence;
        }

        /// <summary>
        /// Get the <see cref="HandsetRental"/>s for a given <see cref="Handset"/>.
        /// </summary>
        /// <param name="handsetNumber">The unique identifier of the <see cref="Handset"/>.</param>
        /// <returns>A collection of the <see cref="HandsetRental"/>s for the given <see cref="Handset"/>.</returns>
        public IEnumerable<HandsetRental> GetRentalsOfHandset(int handsetNumber)
        {
            var number = handsetNumber.ToString(CultureInfo.CurrentCulture);

            var rentals =
                this._persistence.GetRepository<HandsetRental>().GetMany(hr => hr.Handset.HandsetNumber == number);

            return rentals;
        }
    }
}