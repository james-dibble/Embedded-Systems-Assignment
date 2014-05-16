// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICustomerService.cs" company="ESD">
//    Copyright 2013
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace EmbeddedSystems.ServiceLayer
{
    using System.Collections.Generic;
    using EmbeddedSystems.DomainModel;


    public interface IAdministratorService
    {
        Administrator GetAdminByEmail(string email);

        Administrator CreateAdministrator(Administrator admin);
    }
}