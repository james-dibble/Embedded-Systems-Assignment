// --------------------------------------------------------------------------------------------------------------------
// <copyright file="KnowledgeLevel.cs" company="ESD">
//    Copyright 2013
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace EmbeddedSystems.DomainModel
{
    /// <summary>
    /// An object to represent the competency level of an <see cref="ICustomer"/>.
    /// </summary>
    public class KnowledgeLevel : UniqueObject<int>
    {
        /// <summary>
        /// Gets or sets the description of this <see cref="IKnowledgeLevel"/>.
        /// </summary>
        public string Description { get; set; }
    }
}