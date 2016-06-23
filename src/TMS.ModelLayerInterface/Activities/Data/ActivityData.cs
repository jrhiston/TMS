using System;
using TMS.Layer.Data;

namespace TMS.ModelLayerInterface.Activities.Data
{
    public class ActivityData : IData
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
    }
}
