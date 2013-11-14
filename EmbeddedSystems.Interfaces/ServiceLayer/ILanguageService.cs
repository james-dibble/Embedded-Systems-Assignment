// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ILanguageService.cs" company="ESD">
//    Copyright 2013
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace EmbeddedSystems.ServiceLayer
{
    using EmbeddedSystems.DomainModel;

    public interface ILanguageService
    {
        Language GetLanguage(int languageId);
    }
}