namespace EmbeddedSystems.ServiceLayer
{
    using EmbeddedSystems.DomainModel;
    using System.Collections.Generic;

    public interface IKnowledgeLevelService
    {
        IEnumerable<KnowledgeLevel> GetAll();

        KnowledgeLevel GetKnowldegeLevel(int knowledgeLevelId);
    }
}
