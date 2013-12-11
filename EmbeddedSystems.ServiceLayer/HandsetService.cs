// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HandsetService.cs" company="ESD">
//    Copyright 2013
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace EmbeddedSystems.ServiceLayer
{
    using EmbeddedSystems.DomainModel;
    using EmbeddedSystems.Persistence;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    /// <summary>
    /// A class for interacting with <see cref="Handset"/>s.
    /// </summary>
    public class HandsetService : IHandsetService
    {
        private readonly IUnitOfWork _persistence;
        private readonly Random _randomNumberGenerator;

        /// <summary>
        /// Initialises a new instance of the <see cref="HandsetService"/> class.
        /// </summary>
        /// <param name="persistence">The current persistence context.</param>
        public HandsetService(IUnitOfWork persistence)
        {
            this._persistence = persistence;
            this._randomNumberGenerator = new Random();
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
        
        public HandsetRental RentHandset(Customer customer)
        {
            var handset = this.GetAvailableHandsets(DateTime.Now).First();

            var rental = new HandsetRental
            {
                Customer = customer,
                Handset = handset,
                WhenRentedOut = DateTime.Now,
                RentalExpires = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 23, 59, 59),
                Pin = this.GeneratePin()
            };

            this._persistence.GetRepository<HandsetRental>().Add(rental);

            this._persistence.Commit();

            return rental;
        }


        public IEnumerable<Handset> GetAvailableHandsets(DateTime dateAvailableFrom)
        {
            // For now just get all handsets.
            return this._persistence.GetRepository<Handset>().GetAll();
        }

        private int GeneratePin()
        {
            return this._randomNumberGenerator.Next(0, 9999);
        }
    }
}