using System;
using System.Linq;
using TMS.Layer;
using TMS.Layer.Conversion;
using TMS.Layer.Factories;
using TMS.ModelLayer.TMS.ModelLayerInterface.Areas;
using TMS.ModelLayerInterface.Areas;
using TMS.ModelLayerInterface.Areas.Data;
using TMS.ModelLayerInterface.Areas.Decorators;
using TMS.Web.API.Models.Areas;

namespace TMS.Web.API.Converters.Areas
{
    public class AreaViewModelToPersistableAreaConverter : IConverter<AreaViewModel, IPersistableArea>
    {
        private readonly IFactory<AreaData, IArea> _areaFactory;
        private readonly IConverter<AreaViewModel, IAreaKey> _areaViewModelToAreaKeyConverter;
        private readonly IDecoratorFactory<PersistableAreaData, IArea, IPersistableArea> _persistableAreaFactory;

        public AreaViewModelToPersistableAreaConverter(IFactory<AreaData, IArea> areaFactory,
            IDecoratorFactory<PersistableAreaData, IArea, IPersistableArea> persistableAreaFactory,
            IConverter<AreaViewModel, IAreaKey> areaViewModelToAreaKeyConverter)
        {
            _areaFactory = areaFactory;
            _persistableAreaFactory = persistableAreaFactory;
            _areaViewModelToAreaKeyConverter = areaViewModelToAreaKeyConverter;
        }

        public Maybe<IPersistableArea> Convert(AreaViewModel input)
        {
            var area = _areaFactory.Create(new AreaData
            {
                Name = input.Name,
                Description = input.Description,
                Created = DateTime.Now
            });

            var areaKey = _areaViewModelToAreaKeyConverter.Convert(input);

            var persistableArea = _persistableAreaFactory.Create(new PersistableAreaData
            {
                AreaKey = areaKey.FirstOrDefault()
            }, area);

            return new Maybe<IPersistableArea>(persistableArea);
        }
    }
}