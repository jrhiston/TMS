using System;
using TMS.Database.Entities.Areas;
using TMS.Layer;
using TMS.Layer.Conversion;
using TMS.ModelLayerInterface.Areas.Decorators;

namespace TMS.Database.Converters.Areas
{
    public class PersistableAreaToAreaEntityConverter : IConverter<IPersistableArea, AreaEntity>
    {
        public Maybe<AreaEntity> Convert(IPersistableArea input)
        {
            var areaEntity = new AreaEntity();

            areaEntity.Accept(input);

            return new Maybe<AreaEntity>(areaEntity);
        }
    }
}
