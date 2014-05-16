// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CustomerService.cs" company="ESD">
//    Copyright 2013
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EmbeddedSystems.ServiceLayer
{
    using System.Collections.Generic;
    using EmbeddedSystems.DomainModel;
    using EmbeddedSystems.Persistence;
    using System.Linq;
    
    /// <summary>
    /// A class for interacting with <see cref="Customer" />s.
    /// </summary>
    public class AdministratorService : IAdministratorService
    {
        private readonly IUnitOfWork _persistence;

        /// <summary>
        /// Initialises a new instance of the <see cref="CustomerService"/> class.
        /// </summary>
        /// <param name="persistence">The current persistence context.</param>
        public AdministratorService(IUnitOfWork persistence)
        {
            this._persistence = persistence;
        }

        public Administrator GetAdminByEmail(string email)
        {
            return this._persistence.GetRepository<Administrator>().Single(a => a.Email == email);
        }

        public Administrator CreateAdministrator(Administrator admin)
        {
            this._persistence.GetRepository<Administrator>().Add(admin);
            this._persistence.Commit();

            return admin;
        }
    }
}