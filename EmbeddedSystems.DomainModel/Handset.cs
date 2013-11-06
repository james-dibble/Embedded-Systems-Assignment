// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Handset.cs" company="ESD">
//    Copyright 2013
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace EmbeddedSystems.DomainModel
{
    /// <summary>
    /// An object that stores information about a <see cref="IHandset"/>.
    /// </summary>
    public class Handset : UniqueObject<int>, IHandset
    {
        /// <summary>
        /// Gets or sets the number of this <see cref="IHandset"/>.
        /// </summary>
        public string HandsetNumber { get; set; }
    }
}