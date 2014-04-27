// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IAudioFileService.cs" company="ESD">
//    Copyright 2013
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace EmbeddedSystems.ServiceLayer
{
    using System.Collections.Generic;
    using EmbeddedSystems.DomainModel;

    /// <summary>
    /// Implementing classes define methods to interact with <see cref="AudioFile"/>s.
    /// </summary>
    public interface IAudioFileService
    {
        /// <summary>
        /// Retrieve an <see cref="AudioFile"/>.
        /// </summary>
        /// <param name="exhibit">The <see cref="Exhibit"/> to get the audio file for.</param>
        /// <param name="knowledgeLevel">The <see cref="KnowledgeLevel"/> of the <see cref="Customer"/> so they get the right <see cref="AudioFile"/>.</param>
        /// <param name="language">The <see cref="Language"/> of the <see cref="Customer"/> so they get the right <see cref="AudioFile"/>.</param>
        /// <returns>An <see cref="AudioFile"/> that corresponds to the given information.</returns>
        AudioFile GetFile(Exhibit exhibit, KnowledgeLevel knowledgeLevel, Language language);

        /// <summary>
        /// Retrieve all the <see cref="AudioFile"/>s for a given <paramref name="exhibitId"/>.
        /// </summary>
        /// <param name="exhibitId">The unique identifier of the <see cref="Exhibit"/>.</param>
        /// <returns>All the <see cref="AudioFile"/>s for a given <paramref name="exhibitId"/>.</returns>
        IEnumerable<AudioFile> GetFilesForExhibit(int exhibitId);

        /// <summary>
        /// Retrieve all known <see cref="AudioFile"/>s.
        /// </summary>
        /// <returns>All known <see cref="AudioFile"/>s.</returns>
        IEnumerable<AudioFile> GetAll();

        /// <summary>
        /// Build and persist a new <see cref="AudioFile"/>.
        /// </summary>
        /// <param name="audioFile">A new <see cref="AudioFile"/></param>
        /// <returns>The persisted Audio File.</returns>
        AudioFile CreateAudioFile(AudioFile audioFile);
    }
}