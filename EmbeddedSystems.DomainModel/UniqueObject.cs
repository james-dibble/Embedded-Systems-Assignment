﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UniqueObject.cs" company="ESD">
//    Copyright 2013
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace EmbeddedSystems.DomainModel
{
    /// <summary>
    /// A base class for an object with a key that can uniquely identify itself.
    /// </summary>
    /// <typeparam name="TKey">The type of unique identifier.</typeparam>
    public abstract class UniqueObject<TKey>
    {
        /// <summary>
        /// Gets or sets the unique identifier of this <see cref="UniqueObject{TKey}"/>.
        /// </summary>
        public TKey Id { get; set; }
    }
}