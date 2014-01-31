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
    public class Language : UniqueObject<int>
    {
        /// <summary>
        /// Gets or sets the name of this <see cref="Language"/>.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the address of the image for this <see cref="Language"/>s flag.
        /// </summary>
        public string FlagUrl { get; set; }
    }
}