// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IAudioFile.cs" company="ESD">
//    Copyright 2013
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace EmbeddedSystems.DomainModel
{
    using System;

    /// <summary>
    /// An object that represents an <see cref="IExhibit"/>'s audio file.
    /// </summary>
    public interface IAudioFile
    {
        /// <summary>
        /// Gets the <see cref="IExhibit"/> that this <see cref="IAudioFile"/> is for.
        /// </summary>
        IExhibit Exhibit { get; }

        /// <summary>
        /// Gets the <see cref="ILanguage"/> that this <see cref="IAudioFile"/> is spoken in.
        /// </summary>
        ILanguage Language { get; }

        /// <summary>
        /// Gets the <see cref="IKnowledgeLevel"/> of this <see cref="IAudioFile"/>.
        /// </summary>
        IKnowledgeLevel KnowledgeLevel { get; }

        /// <summary>
        /// Gets the location of this <see cref="IAudioFile"/>.
        /// </summary>
        Uri FilePath { get; }
    }
}