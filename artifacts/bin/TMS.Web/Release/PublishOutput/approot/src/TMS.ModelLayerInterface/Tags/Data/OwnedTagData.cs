using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMS.Layer.Data;
using TMS.ModelLayerInterface.People;

namespace TMS.ModelLayerInterface.Tags.Data
{
    public class OwnedTagData : IData
    {
        public IPersonKey Owner { get; set; }
    }
}
