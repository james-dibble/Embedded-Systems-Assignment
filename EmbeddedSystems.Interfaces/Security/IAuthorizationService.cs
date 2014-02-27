// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IAuthorizationService.cs" company="ESD">
//    Copyright 2013
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace EmbeddedSystems.Security
{
    using EmbeddedSystems.DomainModel;

    /// <summary>
    /// Implementing classes define methods to authenticate a <see cref="Handset"/>.
    /// </summary>
    public interface IAuthorizationService
    {
        /// <summary>
        /// Confirm that a handset can be used using the given <paramref name="pin"/>.
        /// </summary>
        /// <param name="handsetNumber">The <see cref="Handset"/> unique identifier.</param>
        /// <param name="pin">The identification number to authorize the use of the <see cref="Handset"/>.</param>
        /// <returns>
        /// The <see cref="HandsetRental"/> represented by the given information or null if the information
        /// does not correspond to a valid <see cref="HandsetRental"/>.
        /// </returns>
        HandsetRental AuthenticateHandsetRental(string handsetNumber, int pin);
    }
}