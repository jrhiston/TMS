using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMS.Layer.Data;
using TMS.ModelLayerInterface.Tags;

namespace TMS.ModelLayerInterface.People.Data
{
    public class TaggablePersonData : IData
    {
        public List<ITag> Tags { get; set; }
    }
}
