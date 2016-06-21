using System;
using TMS.Layer.Visitors;
using TMS.ModelLayer.TMS.ModelLayerInterface.Areas;
using TMS.ModelLayerInterface.Areas.Data;

namespace TMS.ViewModelLayer.Models.Areas
{
    public class AreaListItemViewModel : IVisitor<AreaData>
    {
        public DateTime Created { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }

        public AreaListItemViewModel(IArea area)
        {
            area.Accept(() => this);
        }

        public void Visit(AreaData data)
        {
            Name = data.Name;
            Description = data.Description;
            Created = data.Created;
        }
    }
}
