// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExhibitService.cs" company="ESD">
//    Copyright 2013
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace EmbeddedSystems.ServiceLayer
{
    using EmbeddedSystems.DomainModel;
    using EmbeddedSystems.Persistence;

    public class ExhibitService : IExhibitService
    {
        private readonly IUnitOfWork _persistence;

        public ExhibitService(IUnitOfWork persistence)
        {
            this._persistence = persistence;
        }

        public Exhibit GetExhibit(int exhibitId)
        {
            var exhibit = this._persistence.GetRepository<Exhibit>().Single(e => e.Id == exhibitId);

            return exhibit;
        }
    }
}