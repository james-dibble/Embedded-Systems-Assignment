// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AudioFile.cs" company="ESD">
//    Copyright 2013
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace EmbeddedSystems.DomainModel
{
    /// <summary>
    /// An object that represents an <see cref="Exhibit"/>'s audio file.
    /// </summary>
    public class AudioFile : UniqueObject<int>
    {
        /// <summary>
        /// Gets or sets the the ID of the <see cref="Exhibit"/>. DO NOT USE.
        /// </summary>
        public int ExhibitId { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Exhibit"/> that this <see cref="AudioFile"/> is for.
        /// </summary>
        public virtual Exhibit Exhibit { get; set; }

        /// <summary>
        /// Gets or sets the the ID of the <see cref="Language"/>. DO NOT USE.
        /// </summary>
        public int LanguageId { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Language"/> that this <see cref="AudioFile"/> is spoken in.
        /// </summary>
        public virtual Language Language { get; set; }

        /// <summary>
        /// Gets or sets the the ID of the <see cref="KnowledgeLevel"/>. DO NOT USE.
        /// </summary>
        public int KnowledgeLevelId { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="KnowledgeLevel"/> of this <see cref="AudioFile"/>.
        /// </summary>
        public virtual KnowledgeLevel KnowledgeLevel { get; set; }

        /// <summary>
        /// Gets or sets the location of this <see cref="AudioFile"/>.
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// Gets or sets the name of the <see cref="AudioFile"/>
        /// </summary>
        public string FileName { get; set; }
    }
}