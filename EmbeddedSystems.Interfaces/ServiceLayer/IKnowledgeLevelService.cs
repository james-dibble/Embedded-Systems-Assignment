// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IKnowledgeLevelService.cs" company="ESD">
//    Copyright 2013
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EmbeddedSystems.ServiceLayer
{
    using System.Collections.Generic;
    using EmbeddedSystems.DomainModel;

    /// <summary>
    /// Interface for the KnowledgeLevelService.
    /// </summary>
    public interface IKnowledgeLevelService
    {
        /// <summary>
        /// Get all of the knowledge levels.
        /// </summary>
        /// <returns>A collection containing all of the knowledge levels.</returns>
        IEnumerable<KnowledgeLevel> GetAll();

        /// <summary>
        /// Get a Knowledge level by id.
        /// </summary>
        /// <param name="knowledgeLevelId">The id of the required knowledge level.</param>
        /// <returns>The knowledge level requested.</returns>
        KnowledgeLevel GetKnowledgeLevel(int knowledgeLevelId);

        /// <summary>
        /// Build and persist a new <see cref="KnowledgeLevel"/>.
        /// </summary>
        /// <param name="knowledgeLevelDesc">A new <see cref="KnowledgeLevel"/></param>
        /// <returns>The persisted <see cref="KnowledgeLevel"/>.</returns>
        KnowledgeLevel AddKnowledgeLevel(string knowledgeLevelDesc);

        /// <summary>
        /// Build and persist a new <see cref="KnowledgeLevel"/>.
        /// </summary>
        /// <param name="knowledgeLevel">A new <see cref="KnowledgeLevel"/></param>
        /// <returns>The persisted <see cref="KnowledgeLevel"/>.</returns>
        KnowledgeLevel AddKnowledgeLevel(KnowledgeLevel knowledgeLevel);
    }
}
