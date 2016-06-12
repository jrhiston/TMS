using TMS.Layer;
using TMS.Layer.Conversion;
using TMS.Layer.Factories;
using TMS.ModelLayerInterface.Areas;
using TMS.ModelLayerInterface.Areas.Data;
using TMS.Web.Models.Areas;

namespace TMS.Web.Converters.Areas
{
    public class AreaViewModelToAreaKeyConverter : IConverter<AreaViewModel, IAreaKey>
    {
        private readonly IFactory<AreaKeyData, IAreaKey> _areaKeyFactory;

        public AreaViewModelToAreaKeyConverter(IFactory<AreaKeyData, IAreaKey> areaKeyFactory)
        {
            _areaKeyFactory = areaKeyFactory;
        }

        public Maybe<IAreaKey> Convert(AreaViewModel input)
        {
            IAreaKey areaKey = null;

            var areaId = 0L;
            if (input.AreaId.HasValue)
                areaId = input.AreaId.Value;

            areaKey = _areaKeyFactory.Create(new AreaKeyData
            {
                Identifier = areaId
            });

            return new Maybe<IAreaKey>(areaKey);
        }
    }
}