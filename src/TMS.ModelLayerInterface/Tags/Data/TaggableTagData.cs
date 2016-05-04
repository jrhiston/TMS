using System.Collections.Generic;
using TMS.Layer.Data;

namespace TMS.ModelLayerInterface.Tags.Data
{
    public class TaggableTagData : IData
    {
        public List<ITag> Tags { get; set; }
    }
}
