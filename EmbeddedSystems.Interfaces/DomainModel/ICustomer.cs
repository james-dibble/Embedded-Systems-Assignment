// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICustomer.cs" company="ESD">
//    Copyright 2013
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace EmbeddedSystems.DomainModel
{
    /// <summary>
    /// An object that represents an <see cref="ICustomer"/>.
    /// </summary>
    public interface ICustomer : IUniqueObject<int>
    {
        /// <summary>
        /// Gets the name of this <see cref="ICustomer"/>.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the mobile telephone number of this <see cref="ICustomer"/>.
        /// </summary>
        string MobileNumber { get; }

        /// <summary>
        /// Gets the address of this <see cref="ICustomer"/>.
        /// </summary>
        string Address { get; }

        /// <summary>
        /// Gets the <see cref="ILanguage"/> that this <see cref="ICustomer"/> speaks.
        /// </summary>
        ILanguage Language { get; }

        /// <summary>
        /// Gets the <see cref="IKnowledgeLevel"/> of this <see cref="ICustomer"/>.
        /// </summary>
        IKnowledgeLevel KnowledgeLevel { get; }
    }
}