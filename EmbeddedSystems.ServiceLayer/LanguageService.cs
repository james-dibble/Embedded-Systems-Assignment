// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LanguageService.cs" company="ESD">
//    Copyright 2013
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace EmbeddedSystems.ServiceLayer
{
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
    }
}