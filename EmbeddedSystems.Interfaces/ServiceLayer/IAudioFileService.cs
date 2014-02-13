// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IAudioFileService.cs" company="ESD">
//    Copyright 2013
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace EmbeddedSystems.ServiceLayer
{
    using EmbeddedSystems.DomainModel;
    using System.Collections.Generic;

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

        IEnumerable<AudioFile> GetFilesForExhibit(int exhibitId);
    }
}