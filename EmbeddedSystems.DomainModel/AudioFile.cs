// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AudioFile.cs" company="ESD">
//    Copyright 2013
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace EmbeddedSystems.DomainModel
{
    /// <summary>
    /// An object that represents an <see cref="IExhibit"/>'s audio file.
    /// </summary>
    public class AudioFile : IAudioFile
    {
        /// <summary>
        /// Gets or sets the the ID of the <see cref="IExhibit"/>. DO NOT USE.
        /// </summary>
        public int ExhibitId { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="IExhibit"/> that this <see cref="IAudioFile"/> is for.
        /// </summary>
        public IExhibit Exhibit { get; set; }

        /// <summary>
        /// Gets or sets the the ID of the <see cref="ILanguage"/>. DO NOT USE.
        /// </summary>
        public int LanguageId { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="ILanguage"/> that this <see cref="IAudioFile"/> is spoken in.
        /// </summary>
        public ILanguage Language { get; set; }

        /// <summary>
        /// Gets or sets the the ID of the <see cref="IKnowledgeLevel"/>. DO NOT USE.
        /// </summary>
        public int KnowledgeLevelId { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="IKnowledgeLevel"/> of this <see cref="IAudioFile"/>.
        /// </summary>
        public IKnowledgeLevel KnowledgeLevel { get; set; }

        /// <summary>
        /// Gets or sets the location of this <see cref="IAudioFile"/>.
        /// </summary>
        public string FilePath { get; set; }
    }
}