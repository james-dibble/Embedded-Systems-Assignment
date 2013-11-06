// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IExhibit.cs" company="ESD">
//    Copyright 2013
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace EmbeddedSystems.DomainModel
{
    /// <summary>
    /// An object that represents an item on display.
    /// </summary>
    public interface IExhibit : IUniqueObject<int>
    {
        /// <summary>
        /// Gets the name of this <see cref="IExhibit"/>.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the number of this <see cref="IExhibit"/> that is entered by the use
        /// upon an <see cref="IHandset"/> to get it's audio file.
        /// </summary>
        int HandsetKey { get; }
    }
}