using System;
using System.Linq;
using TMS.ApplicationLayer.Areas.Data;
using TMS.Layer.Initialisers;
using TMS.Layer.Readers;
using TMS.ModelLayer.Areas;
using TMS.ViewModelLayer.Models.Areas;
using TMS.ViewModelLayer.Models.Areas.Pages;

namespace TMS.ApplicationLayer.Areas
{
    public class DeleteAreaPageModelInitialiser : IInitialiser<DeleteAreaPageModelInitialiserData, DeleteAreaPageModel>
    {
        private readonly IReader<AreaKey, Area> _areaReader;

        public DeleteAreaPageModelInitialiser(IReader<AreaKey, Area> areaReader)
        {
            _areaReader = areaReader;
        }

        public DeleteAreaPageModel Initialise(DeleteAreaPageModelInitialiserData data)
        {
            var existingArea = _areaReader.Read(new AreaKey(data.AreaId));

            if (!existingArea.Any())
                throw new InvalidOperationException($"Failed to find area matching the given id {data.AreaId}");

            var areaViewModel = (AreaViewModel) existingArea.FirstOrDefault().Accept(new AreaViewModel());

            return new DeleteAreaPageModel
            {
                Id = areaViewModel.Id,
                Name = areaViewModel.Name
            };
        }
    }
}
