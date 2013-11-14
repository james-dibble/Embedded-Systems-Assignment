// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LanguageService.cs" company="ESD">
//    Copyright 2013
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace EmbeddedSystems.ServiceLayer
{
    using EmbeddedSystems.DomainModel;
    using EmbeddedSystems.Persistence;

    public class LanguageService : ILanguageService
    {
        private readonly IUnitOfWork _persistence;

        public LanguageService(IUnitOfWork persistence)
        {
            this._persistence = persistence;
        }

        public Language GetLanguage(int languageId)
        {
            var language = this._persistence.GetRepository<Language>().Single(l => l.Id == languageId);

            return language;
        }
    }
}