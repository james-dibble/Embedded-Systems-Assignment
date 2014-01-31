namespace EmbeddedSystems.ServiceLayer
{
    using EmbeddedSystems.DomainModel;
    using EmbeddedSystems.Persistence;
    using System.Collections.Generic;

    public class KnowledgeLevelService : IKnowledgeLevelService
    {
        private readonly IUnitOfWork _persistence;

        public KnowledgeLevelService(IUnitOfWork persistence)
        {
            this._persistence = persistence;
        }

        public KnowledgeLevel GetKnowldegeLevel(int knowledgeLevelId)
        {
            var knowledgeLevel = this._persistence.GetRepository<KnowledgeLevel>().Single(kl => kl.Id == knowledgeLevelId);

            return knowledgeLevel;
        }

        public IEnumerable<KnowledgeLevel> GetAll()
        {
            var knowledgeLevels = this._persistence.GetRepository<KnowledgeLevel>().GetAll();

            return knowledgeLevels;
        }
    }
}
