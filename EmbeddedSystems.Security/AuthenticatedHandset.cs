// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AuthenticatedHandset.cs" company="ESD">
//    Copyright 2013
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace EmbeddedSystems.Security
{
    using System.Security.Principal;

    using EmbeddedSystems.DomainModel;

    /// <summary>
    /// An <see cref="IIdentity"/> that is used to represent a <see cref="Handset"/> that 
    /// has made an authenticated request.
    /// </summary>
    public class AuthenticatedHandset : IAuthenticatedHandset
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="AuthenticatedHandset"/> class.
        /// </summary>
        /// <param name="rental">The <see cref="HandsetRental"/> that was used to authenticate the request.</param>
        public AuthenticatedHandset(HandsetRental rental)
        {
            this.Rental = rental;
        }

        /// <summary>
        /// Gets the <see cref="HandsetRental"/> object.
        /// </summary>
        public HandsetRental Rental { get; private set; }

        /// <summary>
        /// Gets the name of the current user.
        /// </summary>
        /// <returns>
        /// The name of the user on whose behalf the code is running.
        /// </returns>
        public string Name
        {
            get
            {
                return this.Rental.Customer.Name;
            }
        }

        /// <summary>
        /// Gets the type of authentication used.
        /// </summary>
        /// <returns>
        /// The type of authentication used to identify the user.
        /// </returns>
        public string AuthenticationType
        {
            get
            {
                return "Basic";
            }
        }

        /// <summary>
        /// Gets a value indicating whether the user has been authenticated.
        /// </summary>
        /// <returns>
        /// true if the user was authenticated; otherwise, false.
        /// </returns>
        public bool IsAuthenticated
        {
            get
            {
                return true;
            }
        }
    }
}