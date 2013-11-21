// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AuthorizationService.cs" company="ESD">
//    Copyright 2013
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace EmbeddedSystems.Security
{
    using System;
    using System.Linq;

    using EmbeddedSystems.DomainModel;
    using EmbeddedSystems.ServiceLayer;

    /// <summary>
    /// A class to authenticate <see cref="Handset"/>s.
    /// </summary>
    public class AuthorizationService : IAuthorizationService
    {
        private readonly IHandsetService _handsetService;

        /// <summary>
        /// Initialises a new instance of the <see cref="AuthorizationService"/> class.
        /// </summary>
        /// <param name="handsetService">The <see cref="IHandsetService"/> to use.</param>
        public AuthorizationService(IHandsetService handsetService)
        {
            this._handsetService = handsetService;
        }

        /// <summary>
        /// Confirm that a handset can be used using the given <paramref name="pin"/>.
        /// </summary>
        /// <param name="handsetNumber">The <see cref="Handset"/> unique identifier.</param>
        /// <param name="pin">The identification number to authorize the use of the <see cref="Handset"/>.</param>
        /// <returns>
        /// The <see cref="HandsetRental"/> represented by the given information or null if the information
        /// does not correspond to a valid <see cref="HandsetRental"/>.
        /// </returns>
        public HandsetRental AuthenticateHandsetRental(int handsetNumber, int pin)
        {
            var rentals = this._handsetService.GetRentalsOfHandset(handsetNumber);

            var now = DateTime.Now;

            var currrentRental = rentals
                .OrderByDescending(r => r.WhenRentedOut)
                .FirstOrDefault(r => r.RentalExpires > now && r.WhenRentedOut < now);

            if (currrentRental == null)
            {
                return null;
            }

            return currrentRental.Pin != pin ? null : currrentRental;
        }
    }
}