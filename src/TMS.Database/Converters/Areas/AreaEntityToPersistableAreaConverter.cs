using TMS.Database.Entities.Areas;
using TMS.Layer;
using TMS.Layer.Conversion;
using TMS.Layer.Factories;
using TMS.ModelLayer.TMS.ModelLayerInterface.Areas;
using TMS.ModelLayerInterface.Areas;
using TMS.ModelLayerInterface.Areas.Data;
using TMS.ModelLayerInterface.Areas.Decorators;

namespace TMS.Database.Converters.Areas
{
    public class AreaEntityToPersistableAreaConverter : IConverter<AreaEntity, IPersistableArea>
    {
        private readonly IFactory<AreaData, IArea> _areaFactory;
        private readonly IFactory<AreaKeyData, IAreaKey> _areaKeyFactory;
        private readonly IDecoratorFactory<PersistableAreaData, IArea, IPersistableArea> _persistableAreaFactory;

        public AreaEntityToPersistableAreaConverter(IFactory<AreaKeyData, IAreaKey> areaKeyFactory,
            IFactory<AreaData, IArea> areaFactory,
            IDecoratorFactory<PersistableAreaData, IArea, IPersistableArea> persistableAreaFactory)
        {
            _areaKeyFactory = areaKeyFactory;
            _areaFactory = areaFactory;
            _persistableAreaFactory = persistableAreaFactory;
        }

        public Maybe<IPersistableArea> Convert(AreaEntity input)
        {
            var areaKey = _areaKeyFactory.Create(new AreaKeyData
            {
                Identifier = input.Id
            });

            var area = _areaFactory.Create(new AreaData
            {
                Name = input.Name,
                Description = input.Description,
                Created = input.Created
            });

            return new Maybe<IPersistableArea>(_persistableAreaFactory.Create(new PersistableAreaData
            {
                AreaKey = areaKey
            }, area));
        }
    }
}
