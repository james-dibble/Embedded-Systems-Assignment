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

        KnowledgeLevel AddKnowledgeLevel(string knowledgeLevelDesc);

        KnowledgeLevel AddKnowledgeLevel(KnowledgeLevel knowledgeLevel);
    }
}
