using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMS.Layer.Data;

namespace TMS.ModelLayerInterface.Tags.Data
{
    public class PersistableTagData : IData
    {
        public ITagKey Key { get; set; }
    }
}
