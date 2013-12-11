namespace EmbeddedSystems.ServiceLayer
{
    using EmbeddedSystems.DomainModel;
    using EmbeddedSystems.Persistence;

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
    }
}
