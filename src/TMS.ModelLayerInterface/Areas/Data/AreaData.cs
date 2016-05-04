using System;
using TMS.Layer.Data;

namespace TMS.ModelLayerInterface.Areas.Data
{
    public class AreaData : IData
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
    }
}
