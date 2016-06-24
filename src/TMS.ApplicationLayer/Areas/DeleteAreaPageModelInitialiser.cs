using System;
using System.Linq;
using TMS.ApplicationLayer.Areas.Data;
using TMS.Layer.Factories;
using TMS.Layer.Initialisers;
using TMS.Layer.Readers;
using TMS.ModelLayerInterface.Areas;
using TMS.ModelLayerInterface.Areas.Data;
using TMS.ModelLayerInterface.Areas.Decorators;
using TMS.ViewModelLayer.Models.Areas;
using TMS.ViewModelLayer.Models.Areas.Pages;

namespace TMS.ApplicationLayer.Areas
{
    public class DeleteAreaPageModelInitialiser : IInitialiser<DeleteAreaPageModelInitialiserData, DeleteAreaPageModel>
    {
        private readonly IFactory<AreaKeyData, IAreaKey> _areaKeyFactory;
        private readonly IReader<IAreaKey, IPersistableArea> _areaReader;

        public DeleteAreaPageModelInitialiser(IReader<IAreaKey, IPersistableArea> areaReader,
            IFactory<AreaKeyData, IAreaKey> areaKeyFactory)
        {
            _areaReader = areaReader;
            _areaKeyFactory = areaKeyFactory;
        }

        public DeleteAreaPageModel Initialise(DeleteAreaPageModelInitialiserData data)
        {
            var areaKey = _areaKeyFactory.Create(new AreaKeyData
            {
                Identifier = data.AreaId
            });

            var existingArea = _areaReader.Read(areaKey);

            if (!existingArea.Any())
                throw new InvalidOperationException($"Failed to find area matching the given id {data.AreaId}");

            var areaViewModel = new AreaViewModel(existingArea.FirstOrDefault());

            return new DeleteAreaPageModel
            {
                Id = areaViewModel.Id,
                Name = areaViewModel.Name
            };
        }
    }
}
