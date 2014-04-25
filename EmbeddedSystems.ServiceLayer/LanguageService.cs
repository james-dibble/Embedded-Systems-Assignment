// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LanguageService.cs" company="ESD">
//    Copyright 2013
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace EmbeddedSystems.ServiceLayer
{
    using System.Collections.Generic;
    using EmbeddedSystems.DomainModel;
    using EmbeddedSystems.Persistence;

    /// <summary>
    /// A class for interacting with <see cref="Language"/>s.
    /// </summary>
    public class LanguageService : ILanguageService
    {
        private readonly IUnitOfWork _persistence;

        /// <summary>
        /// Initialises a new instance of the <see cref="LanguageService"/> class.
        /// </summary>
        /// <param name="persistence">The current persistence context.</param>
        public LanguageService(IUnitOfWork persistence)
        {
            this._persistence = persistence;
        }

        /// <summary>
        /// Retrieve a <see cref="Language"/>.
        /// </summary>
        /// <param name="languageId">The unique identifier of the <see cref="Language"/>.</param>
        /// <returns>The <see cref="Language"/> that matches the given <paramref name="languageId"/>.</returns>
        public Language GetLanguage(int languageId)
        {
            var language = this._persistence.GetRepository<Language>().Single(l => l.Id == languageId);

            return language;
        }

        /// <summary>
        /// Retrieve all <see cref="Language"/>s.
        /// </summary>
        /// <returns>All of the <see cref="Language"/>s in the DB.</returns>
        public IEnumerable<Language> GetAll()
        {
            var languages = this._persistence.GetRepository<Language>().GetAll();
            
            return languages;
        }

        /// <summary>
        /// Build and persist a new <see cref="Language"/>.
        /// </summary>
        /// <param name="languageName">A new <see cref="Language"/></param>
        /// <returns>The persisted <see cref="Language"/>.</returns>
        public Language AddLanguage(string languageName)
        {
            var language = new Language()
            {
                Name = languageName,
                FlagUrl = null
            };

            return this.AddLanguage(language);
        }

        /// <summary>
        /// Build and persist a new <see cref="Language"/>.
        /// </summary>
        /// <param name="language">A new <see cref="Language"/></param>
        /// <returns>The persisted <see cref="Language"/>.</returns>
        public Language AddLanguage(Language language)
        {
            this._persistence.GetRepository<Language>().Add(language);
            this._persistence.Commit();

            return language;
        }
    }
}