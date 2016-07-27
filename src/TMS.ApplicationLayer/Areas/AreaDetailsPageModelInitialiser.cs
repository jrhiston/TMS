using System;
using System.Linq;
using TMS.ApplicationLayer.Areas.Data;
using TMS.Layer.Factories;
using TMS.Layer.Initialisers;
using TMS.Layer.Readers;
using TMS.ModelLayerInterface.Areas;
using TMS.ModelLayerInterface.Areas.Data;
using TMS.ViewModelLayer.Models.Areas;
using TMS.ViewModelLayer.Models.Areas.Pages;

namespace TMS.ApplicationLayer.Areas
{
    public class AreaDetailsPageModelInitialiser : IInitialiser<AreaDetailsPageModelInitialiserData, AreaDetailsPageModel>
    {
        private readonly IFactory<AreaKeyData, IAreaKey> _areaKeyFactory;
        private readonly IReader<IAreaKey, IArea> _areaReader;

        public AreaDetailsPageModelInitialiser(IReader<IAreaKey, IArea> areaReader,
            IFactory<AreaKeyData, IAreaKey> areaKeyFactory)
        {
            _areaReader = areaReader;
            _areaKeyFactory = areaKeyFactory;
        }

        public AreaDetailsPageModel Initialise(AreaDetailsPageModelInitialiserData data)
        {
            var areaKey = _areaKeyFactory.Create(new AreaKeyData
            {
                Identifier = data.AreaId
            });

            var area = _areaReader.Read(areaKey);

            if (!area.Any())
                throw new InvalidOperationException($"Failed to find area for given identifier {data.AreaId}");

            var areaViewModel = new AreaViewModel(area.FirstOrDefault());

            return new AreaDetailsPageModel
            {
                AreaId = areaViewModel.Id,
                AreaName = areaViewModel.Name,
                AreaDescription = areaViewModel.Description,
                Activities = areaViewModel.Activities,
                AssociatedPeople = areaViewModel.AssociatedPeople
            };
        }
    }
}
