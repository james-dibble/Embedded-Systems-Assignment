// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ILanguage.cs" company="ESD">
//    Copyright 2013
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace EmbeddedSystems.DomainModel
{
    /// <summary>
    /// An object that represents a spoken tongue.
    /// </summary>
    public interface ILanguage : IUniqueObject<int>
    {
        /// <summary>
        /// Gets the name of this <see cref="ILanguage"/>.
        /// </summary>
        string Name { get; }
    }
}