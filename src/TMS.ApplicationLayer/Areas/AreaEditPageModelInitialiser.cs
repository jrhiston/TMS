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
    public class AreaEditPageModelInitialiser : IInitialiser<AreaEditPageModelInitialiserData, AreaEditPageModel>
    {
        private readonly IReader<AreaKey, Area> _areaReader;

        public AreaEditPageModelInitialiser(IReader<AreaKey, Area> areaReader)
        {
            _areaReader = areaReader;
        }

        public AreaEditPageModel Initialise(AreaEditPageModelInitialiserData data)
        {
            var area = _areaReader.Read(new AreaKey(data.AreaId));

            if (!area.Any())
                throw new InvalidOperationException($"Failed to find area for given identifier {data.AreaId}");

            var areaViewModel = (AreaViewModel) area.Single().Accept(new AreaViewModel());

            return new AreaEditPageModel
            {
                AreaId = areaViewModel.Id,
                Name = areaViewModel.Name,
                Description = areaViewModel.Description
            };
        }
    }
}
