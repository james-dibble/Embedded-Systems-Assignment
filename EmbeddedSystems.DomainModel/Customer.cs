// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Customer.cs" company="ESD">
//    Copyright 2013
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace EmbeddedSystems.DomainModel
{
    /// <summary>
    /// An object that represents an <see cref="Customer"/>.
    /// </summary>
    public class Customer : UniqueObject<int>
    {
        /// <summary>
        /// Gets or sets the name of this <see cref="Customer"/>.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the email of this <see cref="Customer"/>.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the mobile telephone number of this <see cref="Customer"/>.
        /// </summary>
        public string MobileNumber { get; set; }

        /// <summary>
        /// Gets or sets the address of this <see cref="Customer"/>.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Language"/> that this <see cref="Customer"/> speaks.
        /// </summary>
        public virtual Language Language { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="KnowledgeLevel"/> of this <see cref="Customer"/>.
        /// </summary>
        public virtual KnowledgeLevel KnowledgeLevel { get; set; }
    }
}