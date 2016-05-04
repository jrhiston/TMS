using TMS.Layer.Factories;
using TMS.ModelLayerInterface.Areas;
using TMS.ModelLayerInterface.Areas.Data;

namespace TMS.ModelLayer.Areas.Factories
{
    public class AreaKeyFactory : IFactory<AreaKeyData, IAreaKey>
    {
        public IAreaKey Create(AreaKeyData data) => new AreaKey
        {
            Identifier = data.Identifier
        };
    }
}
