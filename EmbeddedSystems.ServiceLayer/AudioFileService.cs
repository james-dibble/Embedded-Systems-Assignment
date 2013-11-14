// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AudioFileService.cs" company="ESD">
//    Copyright 2013
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace EmbeddedSystems.ServiceLayer
{
    using EmbeddedSystems.DomainModel;
    using EmbeddedSystems.Persistence;

    public class AudioFileService : IAudioFileService
    {
        private readonly IUnitOfWork _persistence;

        public AudioFileService(IUnitOfWork persistence)
        {
            this._persistence = persistence;
        }

        public AudioFile GetFile(Exhibit exhibit, KnowledgeLevel knowledgeLevel, Language language)
        {
            var file =
                this._persistence.GetRepository<AudioFile>()
                    .Single(
                        af =>
                            af.Exhibit.Id == exhibit.Id 
                            && af.KnowledgeLevel.Id == knowledgeLevel.Id
                            && af.Language.Id == language.Id);

            return file;
        }
    }
}