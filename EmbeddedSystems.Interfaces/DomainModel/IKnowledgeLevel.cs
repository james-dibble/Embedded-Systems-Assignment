// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IKnowledgeLevel.cs" company="ESD">
//    Copyright 2013
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace EmbeddedSystems.DomainModel
{
    /// <summary>
    /// An object to represent the competency level of an <see cref="ICustomer"/>.
    /// </summary>
    public interface IKnowledgeLevel : IUniqueObject<int>
    {
        /// <summary>
        /// Gets the description of this <see cref="IKnowledgeLevel"/>.
        /// </summary>
        string Description { get; }
    }
}