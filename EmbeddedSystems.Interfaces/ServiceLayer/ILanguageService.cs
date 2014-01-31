﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ILanguageService.cs" company="ESD">
//    Copyright 2013
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace EmbeddedSystems.ServiceLayer
{
    using EmbeddedSystems.DomainModel;
    using System.Collections.Generic;

    /// <summary>
    /// Implementing classes define methods for interacting with <see cref="Language"/>s.
    /// </summary>
    public interface ILanguageService
    {
        /// <summary>
        /// Retrieve a <see cref="Language"/>.
        /// </summary>
        /// <param name="languageId">The unique identifier of the <see cref="Language"/>.</param>
        /// <returns>The <see cref="Language"/> that matches the given <paramref name="languageId"/>.</returns>
        Language GetLanguage(int languageId);

        /// <summary>
        /// Retrieve all <see cref="Language"/>s
        /// </summary>
        /// <returns>All of the <see cref="Language"/>s in the DB.</returns>
        IEnumerable<Language> GetAll();
    }
}