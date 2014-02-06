// --------------------------------------------------------------------------------------------------------------------
// <copyright file="KnowledgeLevelService.cs" company="ESD">
//    Copyright 2013
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace EmbeddedSystems.ServiceLayer
{
    using System.Collections.Generic;
    using EmbeddedSystems.DomainModel;
    using EmbeddedSystems.Persistence;
    
    /// <summary>
    /// Methods for getting and setting information about knowledge levels.
    /// </summary>
    public class KnowledgeLevelService : IKnowledgeLevelService
    {
        private readonly IUnitOfWork _persistence;

        /// <summary>
        /// Initialises a new instance of the <see cref="KnowledgeLevelService"/> class.
        /// </summary>
        /// <param name="persistence">Inject the unit of work so that database calls can be made.</param>
        public KnowledgeLevelService(IUnitOfWork persistence)
        {
            this._persistence = persistence;
        }

        /// <summary>
        /// Get the knowledge level by id.
        /// </summary>
        /// <param name="knowledgeLevelId">The id of the knowledge level.</param>
        /// <returns>The knowledge level requested.</returns>
        public KnowledgeLevel GetKnowledgeLevel(int knowledgeLevelId)
        {
            var knowledgeLevel = this._persistence.GetRepository<KnowledgeLevel>().Single(kl => kl.Id == knowledgeLevelId);

            return knowledgeLevel;
        }

        /// <summary>
        /// Get a collection of all the knowledge level.
        /// </summary>
        /// <returns>The collection of knowledge levels.</returns>
        public IEnumerable<KnowledgeLevel> GetAll()
        {
            var knowledgeLevels = this._persistence.GetRepository<KnowledgeLevel>().GetAll();

            return knowledgeLevels;
        }
    }
}
