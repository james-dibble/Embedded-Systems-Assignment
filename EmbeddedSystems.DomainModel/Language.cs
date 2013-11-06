// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Language.cs" company="ESD">
//    Copyright 2013
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace EmbeddedSystems.DomainModel
{
    /// <summary>
    /// An object that represents a spoken tongue.
    /// </summary>
    public class Language : UniqueObject<int>, ILanguage
    {
        /// <summary>
        /// Gets or sets the name of this <see cref="ILanguage"/>.
        /// </summary>
        public string Name { get; set; }
    }
}