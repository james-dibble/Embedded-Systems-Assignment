// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IHandset.cs" company="ESD">
//    Copyright 2013
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace EmbeddedSystems.DomainModel
{
    /// <summary>
    /// An object that stores information about a <see cref="IHandset"/>.
    /// </summary>
    public interface IHandset : IUniqueObject<int>
    {
        /// <summary>
        /// Gets the number of this <see cref="IHandset"/>.
        /// </summary>
         string HandsetNumber { get; }
    }
}