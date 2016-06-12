using System;
using TMS.Layer.Visitors;
using TMS.ModelLayer.TMS.ModelLayerInterface.Areas;
using TMS.ModelLayerInterface.Areas.Data;

namespace TMS.Web.API.Models.Areas
{
    public class AreaViewModel : IVisitor<AreaData>, IVisitor<PersistableAreaData>
    {
        public long? AreaId { get; set; }
        public DateTime? Created { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }

        public AreaViewModel()
        {
        }

        public AreaViewModel(IArea area)
        {
            if (area == null)
                throw new ArgumentNullException(nameof(area));

            area.Accept(() => this);
        }
        
        public void Visit(PersistableAreaData data)
        {
            AreaId = data.AreaKey.Identifier;
        }

        public void Visit(AreaData data)
        {
            Name = data.Name;
            Description = data.Description;
            Created = data.Created;
        }
    }
}