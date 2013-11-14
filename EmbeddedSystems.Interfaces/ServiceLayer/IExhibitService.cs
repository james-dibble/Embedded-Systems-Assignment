// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IExhibitService.cs" company="ESD">
//    Copyright 2013
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace EmbeddedSystems.ServiceLayer
{
    using EmbeddedSystems.DomainModel;

    public interface IExhibitService
    {
        Exhibit GetExhibit(int exhibitId);
    }
}