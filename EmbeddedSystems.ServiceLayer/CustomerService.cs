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
    
    /// <summary>
    /// A class for interacting with <see cref="Customer" />s.
    /// </summary>
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _persistence;

        /// <summary>
        /// Initialises a new instance of the <see cref="CustomerService"/> class.
        /// </summary>
        /// <param name="persistence">The current persistence context.</param>
        public CustomerService(IUnitOfWork persistence)
        {
            this._persistence = persistence;
        }

        /// <summary>
        /// Retrieve a <see cref="Customer"/>.
        /// </summary>
        /// <param name="customerId">The unique identifier of the <see cref="Customer"/>.</param>
        /// <returns>The <see cref="Customer"/> that matches the given <paramref name="customerId"/>.</returns>
        public Customer GetCustomer(int customerId)
        {
            var customer = this._persistence.GetRepository<Customer>().Single(c => c.Id == customerId);

            return customer;
        }

        /// <summary>
        /// Create a new customer.
        /// </summary>
        /// <param name="name">The name of the new customer.</param>
        /// <param name="email">The email address of the new customer.</param>
        /// <param name="mobile">The mobile number of the new customer.</param>
        /// <param name="address">The address of the new customer.</param>
        /// <param name="language">The language of the new customer.</param>
        /// <param name="knowledgeLevel">The knowledge level of the new customer.</param>
        /// <returns>The newly created customer.</returns>
        public Customer CreateCustomer(string name, string email, string mobile, string address, Language language, KnowledgeLevel knowledgeLevel)
        {
            var newCustomer = new Customer
            {
                Name = name,
                Email = email,
                MobileNumber = mobile,
                Address = address,
                Language = language,
                KnowledgeLevel = knowledgeLevel
            };

            this.CreateCustomer(newCustomer);

            return newCustomer;
        }

        /// <summary>
        /// Create a new customer with a given customer object.
        /// </summary>
        /// <param name="customer">The customer to be added.</param>
        /// <returns>The newly created customer.</returns>
        public Customer CreateCustomer(Customer customer)
        {
            this._persistence.GetRepository<Customer>().Add(customer);
            this._persistence.Commit();

            return customer;
        }

        /// <summary>
        /// Get all of the customers.
        /// </summary>
        /// <returns>All of the customers.</returns>
        public IEnumerable<Customer> GetAllCustomers()
        {
            var allCustomers = this._persistence.GetRepository<Customer>().GetAll();

            return allCustomers;
        }
    }
}