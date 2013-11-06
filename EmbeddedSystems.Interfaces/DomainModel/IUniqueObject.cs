// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUniqueObject.cs" company="ESD">
//    Copyright 2013
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace EmbeddedSystems.DomainModel
{
    /// <summary>
    /// Implementing classes refer to an object with a key that can uniquely identify itself.
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    public interface IUniqueObject<out TKey>
    {
        /// <summary>
        /// Gets the unique identifier of this <see cref="IUniqueObject{TKey}"/>.
        /// </summary>
        TKey Id { get; }
    }
}