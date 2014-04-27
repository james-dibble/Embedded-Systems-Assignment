// --------------------------------------------------------------------------------------------------------------------
// <copyright file="KnowledgeLevel.cs" company="ESD">
//    Copyright 2013
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EmbeddedSystems.DomainModel
{
    /// <summary>
    /// An object to represent the competency level of an <see cref="Customer"/>.
    /// </summary>
    public class KnowledgeLevel : UniqueObject<int>
    {
        /// <summary>
        /// Gets or sets the description of this <see cref="KnowledgeLevel"/>.
        /// </summary>
        public string Description { get; set; }
    }
}