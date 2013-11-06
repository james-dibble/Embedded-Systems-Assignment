﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Customer.cs" company="ESD">
//    Copyright 2013
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace EmbeddedSystems.DomainModel
{
    /// <summary>
    /// An object that represents an <see cref="ICustomer"/>.
    /// </summary>
    public class Customer : UniqueObject<int>, ICustomer
    {
        /// <summary>
        /// Gets or sets the name of this <see cref="ICustomer"/>.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the mobile telephone number of this <see cref="ICustomer"/>.
        /// </summary>
        public string MobileNumber { get; set; }

        /// <summary>
        /// Gets or sets the address of this <see cref="ICustomer"/>.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="ILanguage"/> that this <see cref="ICustomer"/> speaks.
        /// </summary>
        public ILanguage Language { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="IKnowledgeLevel"/> of this <see cref="ICustomer"/>.
        /// </summary>
        public IKnowledgeLevel KnowledgeLevel { get; set; }
    }
}