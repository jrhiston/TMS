using System;
using TMS.Layer.ModelObjects;
using TMS.ModelLayerInterface.Areas;
using TMS.ModelLayerInterface.Areas.Data;
using TMS.ModelLayerInterface.Areas.Decorators;

namespace TMS.ModelLayer.Areas.Decorators
{
    public class PersistableArea : DecoratorBase<PersistableAreaData, AreaData>, IPersistableArea
    {
        private readonly IAreaKey _areaKey;

        public PersistableArea(IArea area,
            PersistableAreaData data) : base(area)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));
            
            _areaKey = data.AreaKey;
        }

        protected override PersistableAreaData GetData() => new PersistableAreaData
        {
            AreaKey = _areaKey
        };
    }
}
