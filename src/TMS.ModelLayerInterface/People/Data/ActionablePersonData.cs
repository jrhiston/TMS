using System.Collections.Generic;
using TMS.Layer.Data;
using TMS.ModelLayerInterface.Activities;

namespace TMS.ModelLayerInterface.People.Data
{
    public class ActionablePersonData : IData
    {
        public List<IActivity> Activities { get; set; }
    }
}
