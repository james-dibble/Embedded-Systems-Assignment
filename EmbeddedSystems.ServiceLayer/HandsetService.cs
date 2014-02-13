// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HandsetService.cs" company="ESD">
//    Copyright 2013
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace EmbeddedSystems.ServiceLayer
{
    using System;
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
        
        /// <summary>
        /// Rent a handset.
        /// </summary>
        /// <param name="customer">The customer requesting the handset rental.</param>
        /// <returns>A new handset rental.</returns>
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

        /// <summary>
        /// Get all rentals for a given customer.
        /// </summary>
        /// <param name="customerId">The id of the customer.</param>
        /// <returns>A collection of handset rentals belonging to a customer.</returns>
        public IEnumerable<HandsetRental> GetAllRentalsForCustomer(int customerId)
        {
            var allCustomerRentals = this._persistence.GetRepository<HandsetRental>().GetMany(hs => hs.Customer.Id == customerId);

            return allCustomerRentals;
        }

        /// <summary>
        /// Get the available handsets.
        /// </summary>
        /// <param name="dateAvailableFrom">The date from which will be checked.</param>
        /// <returns>A collection of available handsets.</returns>
        public IEnumerable<Handset> GetAvailableHandsets(DateTime dateAvailableFrom)
        {
            // For now just get all handsets.
            //return this._persistence.GetRepository<Handset>().GetAll();

            var handsets = this._persistence.GetRepository<Handset>().GetAll();

            var availableHandsets = handsets.Where(h => h.Rentals.All(hr => hr.RentalExpires < DateTime.Now));

            return availableHandsets;

        }

        /// <summary>
        /// Generate a 4 digit pin number.
        /// </summary>
        /// <returns>The generated pin number.</returns>
        private int GeneratePin()
        {
            return this._randomNumberGenerator.Next(1000, 9999);
        }

        public IEnumerable<HandsetRental> GetAllRentals()
        {
            return this._persistence.GetRepository<HandsetRental>().GetAll();
        }

        public IEnumerable<Handset> GetAllHandsets()
        {
            return this._persistence.GetRepository<Handset>().GetAll();
        }

        public Handset GetHandset(int handsetId)
        {
            return this._persistence.GetRepository<Handset>().Single(x => x.Id == handsetId);
        }

        public HandsetRental GetCurrentRentalForHandset(int handsetId)
        {
           return this._persistence.GetRepository<HandsetRental>().GetMany(hr=>hr.HandsetId == handsetId)
               .FirstOrDefault(hr => hr.WhenRentedOut < DateTime.Now && hr.RentalExpires > DateTime.Now);
        }

        public void ExpireRental(HandsetRental rental)
        {
            rental.RentalExpires = DateTime.Now;
            this._persistence.Commit();
        }

        public Handset CreateHandset(string handsetNumber)
        {
            var handset = new Handset
            {
                HandsetNumber = handsetNumber
            };

            this._persistence.GetRepository<Handset>().Add(handset);
            this._persistence.Commit();

            return handset;
        }
    }
}