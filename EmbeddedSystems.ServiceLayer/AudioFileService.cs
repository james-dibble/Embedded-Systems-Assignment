// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AudioFileService.cs" company="ESD">
//    Copyright 2013
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace EmbeddedSystems.ServiceLayer
{
    using System.Collections.Generic;
    using System.Configuration;
    using System.IO;

    using EmbeddedSystems.DomainModel;
    using EmbeddedSystems.Persistence;

    /// <summary>
    /// A class for interacting with <see cref="AudioFile"/>s.
    /// </summary>
    public class AudioFileService : IAudioFileService
    {
        private readonly IUnitOfWork _persistence;

        /// <summary>
        /// Initialises a new instance of the <see cref="AudioFileService"/> class.
        /// </summary>
        /// <param name="persistence">The current persistence context.</param>
        public AudioFileService(IUnitOfWork persistence)
        {
            this._persistence = persistence;
        }

        /// <summary>
        /// Retrieve an <see cref="AudioFile"/>.
        /// </summary>
        /// <param name="exhibit">The <see cref="Exhibit"/> to get the audio file for.</param>
        /// <param name="knowledgeLevel">The <see cref="KnowledgeLevel"/> of the <see cref="Customer"/> so they get the right <see cref="AudioFile"/>.</param>
        /// <param name="language">The <see cref="Language"/> of the <see cref="Customer"/> so they get the right <see cref="AudioFile"/>.</param>
        /// <returns>An <see cref="AudioFile"/> that corresponds to the given information.</returns>
        public AudioFile GetFile(Exhibit exhibit, KnowledgeLevel knowledgeLevel, Language language)
        {
            var file =
                this._persistence.GetRepository<AudioFile>()
                    .Single(
                        af =>
                            af.Exhibit.Id == exhibit.Id 
                            && af.KnowledgeLevel.Id == knowledgeLevel.Id
                            && af.Language.Id == language.Id);

            file.FilePath = Path.Combine(ConfigurationManager.AppSettings["RemoteAudioFilePath"], file.FilePath);

            return file;
        }

        /// <summary>
        /// Retrieve all the <see cref="AudioFile"/>s for a given <paramref name="exhibitId"/>.
        /// </summary>
        /// <param name="exhibitId">The unique identifier of the <see cref="Exhibit"/>.</param>
        /// <returns>All the <see cref="AudioFile"/>s for a given <paramref name="exhibitId"/>.</returns>
        public IEnumerable<AudioFile> GetFilesForExhibit(int exhibitId)
        {
            var files = this._persistence.GetRepository<AudioFile>().GetMany(af => af.Exhibit.Id == exhibitId);

            return files;
        }

        /// <summary>
        /// Retrieve all known <see cref="AudioFile"/>s.
        /// </summary>
        /// <returns>All known <see cref="AudioFile"/>s.</returns>
        public IEnumerable<AudioFile> GetAll()
        {
            var files = this._persistence.GetRepository<AudioFile>().GetAll();

            return files;
        }

        /// <summary>
        /// Build and persist a new <see cref="AudioFile"/>.
        /// </summary>
        /// <param name="audioFile">A new <see cref="AudioFile"/></param>
        /// <returns>The persisted Audio File.</returns>
        public AudioFile CreateAudioFile(AudioFile audioFile)
        {
            this._persistence.GetRepository<AudioFile>().Add(audioFile);
            this._persistence.Commit();

            return audioFile;
        }
    }
}