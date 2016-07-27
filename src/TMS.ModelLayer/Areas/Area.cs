using System;
using TMS.Layer.ModelObjects;
using TMS.ModelLayerInterface.Areas;
using TMS.ModelLayerInterface.Areas.Data;

namespace TMS.ModelLayer.Areas
{
    public class Area : ModelObjectBase<AreaData>, IArea
    {
        private readonly DateTime _created;
        private readonly string _description;
        private readonly string _name;

        public Area(AreaData data)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));

            _name = data.Name;
            _description = data.Description;
            _created = data.Created;
        }

        protected override AreaData GetData() => new AreaData
        {
            Name = _name,
            Description = _description,
            Created = _created
        };
    }
}
