// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IAuthenticatedHandset.cs" company="ESD">
//    Copyright 2013
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace EmbeddedSystems.Security
{
    using System.Security.Principal;

    using EmbeddedSystems.DomainModel;

    /// <summary>
    /// Implementing classes define an <see cref="IIdentity"/> that represents a <see cref="Handset"/>
    /// being used.
    /// </summary>
    public interface IAuthenticatedHandset : IIdentity
    {
        /// <summary>
        /// Gets the <see cref="HandsetRental"/> object.
        /// </summary>
        HandsetRental Rental { get; }
    }
}