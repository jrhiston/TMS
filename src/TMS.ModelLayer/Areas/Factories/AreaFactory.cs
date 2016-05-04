using TMS.Layer.Factories;
using TMS.ModelLayer.TMS.ModelLayerInterface.Areas;
using TMS.ModelLayerInterface.Areas.Data;

namespace TMS.ModelLayer.Areas.Factories
{
    public class AreaFactory : IFactory<AreaData, IArea>
    {
        public IArea Create(AreaData data) => new Area(data);
    }
}
