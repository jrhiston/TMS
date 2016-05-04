using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMS.Layer.Data;
using TMS.ModelLayer.TMS.ModelLayerInterface.Areas;

namespace TMS.ModelLayerInterface.Activities.Data
{
    public class ActivityAreaData : IData
    {
        public IArea Area { get; set; }
    }
}
