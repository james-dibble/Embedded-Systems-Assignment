namespace EmbeddedSystems.ServiceLayer
{
    using EmbeddedSystems.DomainModel;

    public interface IKnowledgeLevelService
    {
        KnowledgeLevel GetKnowldegeLevel(int knowledgeLevelId);
    }
}
