using System;
using TMS.Layer.Visitors;
using TMS.ModelLayerInterface.Areas;
using TMS.ModelLayerInterface.Areas.Data;

namespace TMS.ViewModelLayer.Models.Areas
{
    public class AreaListItemViewModel : IVisitor<AreaData>, IVisitor<PersistableAreaData>
    {
        public long Id { get; set; }
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

        public void Visit(PersistableAreaData data)
        {
            Id = data.AreaKey?.Identifier ?? 0;
        }
    }
}
