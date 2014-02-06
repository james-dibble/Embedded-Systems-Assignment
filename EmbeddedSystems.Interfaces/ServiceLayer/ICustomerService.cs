// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICustomerService.cs" company="ESD">
//    Copyright 2013
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace EmbeddedSystems.ServiceLayer
{
    using System.Collections.Generic;
    using EmbeddedSystems.DomainModel;

    /// <summary>
    /// Implementing classes define methods for interacting with <see cref="Customer"/>s.
    /// </summary>
    public interface ICustomerService
    {
        /// <summary>
        /// Retrieve a <see cref="Customer"/>.
        /// </summary>
        /// <param name="customerId">The unique identifier of the <see cref="Customer"/>.</param>
        /// <returns>The <see cref="Customer"/> that matches the given <paramref name="customerId"/>.</returns>
        Customer GetCustomer(int customerId);

        /// <summary>
        /// Will create a new customer and return it.
        /// </summary>
        /// <param name="name">The name for the new customer.</param>
        /// <param name="email">The email address of the new customer.</param>
        /// <param name="mobile">The mobile number for the new customer.</param>
        /// <param name="address">The address for the new customer.</param>
        /// <param name="language">The language for the new customer.</param>
        /// <param name="knowledgeLevel">The knowledge level of the new customer.</param>
        /// <returns>The new customer.</returns>
        Customer CreateCustomer(string name, string email, string mobile, string address, Language language, KnowledgeLevel knowledgeLevel);

        /// <summary>
        /// Create a new customer with a customer object.
        /// </summary>
        /// <param name="customer">The customer to save to the database.</param>
        /// <returns>The newly created customer.</returns>
        Customer CreateCustomer(Customer customer);

        /// <summary>
        /// Get all of the customers.
        /// </summary>
        /// <returns>A collection containing all customers.</returns>
        IEnumerable<Customer> GetAllCustomers();
    }
}