using System;
using TMS.Layer.Data;

namespace TMS.ModelLayerInterface.Tags.Data
{
    public class TagData : IData
    {
        public DateTime Created { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public bool CanSetOnActivity { get; set; }
        public bool Reusable { get; set; }
    }
}
