// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IAudioFileService.cs" company="ESD">
//    Copyright 2013
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace EmbeddedSystems.ServiceLayer
{
    using EmbeddedSystems.DomainModel;

    public interface IAudioFileService
    {
        AudioFile GetFile(Exhibit exhibit, KnowledgeLevel knowledgeLevel, Language language);
    }
}