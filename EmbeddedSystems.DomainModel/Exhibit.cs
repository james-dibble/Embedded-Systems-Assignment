// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Exhibit.cs" company="ESD">
//    Copyright 2013
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace EmbeddedSystems.DomainModel
{
    /// <summary>
    /// An object that represents an item on display.
    /// </summary>
    public class Exhibit : UniqueObject<int>, IExhibit
    {
        /// <summary>
        /// Gets or sets the name of this <see cref="IExhibit"/>.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the number of this <see cref="IExhibit"/> that is entered by the use
        /// upon an <see cref="IHandset"/> to get it's audio file.
        /// </summary>
        public int HandsetKey { get; set; }
    }
}