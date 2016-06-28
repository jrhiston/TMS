using System;
using System.Linq;
using TMS.ApplicationLayer.Areas.Data;
using TMS.Layer.Factories;
using TMS.Layer.Initialisers;
using TMS.Layer.Readers;
using TMS.ModelLayer.TMS.ModelLayerInterface.Areas;
using TMS.ModelLayerInterface.Areas;
using TMS.ModelLayerInterface.Areas.Data;
using TMS.ViewModelLayer.Models.Areas;
using TMS.ViewModelLayer.Models.Areas.Pages;

namespace TMS.ApplicationLayer.Areas
{
    public class AreaEditPageModelInitialiser : IInitialiser<AreaEditPageModelInitialiserData, AreaEditPageModel>
    {
        private readonly IFactory<AreaKeyData, IAreaKey> _areaKeyFactory;
        private readonly IReader<IAreaKey, IArea> _areaReader;

        public AreaEditPageModelInitialiser(IReader<IAreaKey, IArea> areaReader,
            IFactory<AreaKeyData, IAreaKey> areaKeyFactory)
        {
            _areaReader = areaReader;
            _areaKeyFactory = areaKeyFactory;
        }

        public AreaEditPageModel Initialise(AreaEditPageModelInitialiserData data)
        {
            var areaKey = _areaKeyFactory.Create(new AreaKeyData
            {
                Identifier = data.AreaId
            });

            var area = _areaReader.Read(areaKey);

            if (!area.Any())
                throw new InvalidOperationException($"Failed to find area for given identifier {data.AreaId}");

            var areaViewModel = new AreaViewModel(area.FirstOrDefault());

            return new AreaEditPageModel
            {
                AreaId = areaViewModel.Id,
                Name = areaViewModel.Name,
                Description = areaViewModel.Description
            };
        }
    }
}
