// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AudioFileService.cs" company="ESD">
//    Copyright 2013
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EmbeddedSystems.ServiceLayer
{
    using EmbeddedSystems.DomainModel;
    using EmbeddedSystems.Persistence;

    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _persistence;

        public CustomerService(IUnitOfWork persistence)
        {
            this._persistence = persistence;
        }

        public Customer GetCustomer(int customerId)
        {
            var customer = this._persistence.GetRepository<Customer>().Single(c => c.Id == customerId);

            return customer;
        }
    }
}
