// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICustomerService.cs" company="ESD">
//    Copyright 2013
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace EmbeddedSystems.ServiceLayer
{
    using EmbeddedSystems.DomainModel;

    public interface ICustomerService
    {
        Customer GetCustomer(int customerId);
    }
}