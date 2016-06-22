using System.Collections.Generic;
using TMS.Layer.Data;
using TMS.ModelLayerInterface.People.Decorators;

namespace TMS.ModelLayerInterface.Areas.Data
{
    public class AreaWithPeopleData : IData
    {
        public List<IPersistablePerson> People { get; set; }
    }
}
