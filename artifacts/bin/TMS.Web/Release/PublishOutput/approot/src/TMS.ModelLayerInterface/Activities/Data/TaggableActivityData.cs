using System.Collections.Generic;
using TMS.Layer.Data;
using TMS.ModelLayerInterface.Tags;

namespace TMS.ModelLayerInterface.Activities.Data
{
    public class TaggableActivityData : IData
    {
        public IEnumerable<ITag> Tags { get; set; }
    }
}
