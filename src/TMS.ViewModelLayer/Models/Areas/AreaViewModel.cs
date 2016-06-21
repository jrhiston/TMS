using System;
using System.Collections.Generic;
using System.Linq;
using TMS.Layer.Visitors;
using TMS.ModelLayer.TMS.ModelLayerInterface.Areas;
using TMS.ModelLayerInterface.Areas.Data;
using TMS.ViewModelLayer.Models.Activities;

namespace TMS.ViewModelLayer.Models.Areas
{
    public class AreaViewModel : IVisitor<AreaData>, IVisitor<PersistableActivitiesAreaData>
    {
        public string Name { get; set; }
        public string Description { get; private set; }
        public DateTime Created { get; private set; }
        public List<ActivityViewModel> Activities { get; set; }

        public AreaViewModel()
        {
        }

        public AreaViewModel(IArea area)
        {
            area.Accept(() => this);
        }

        public void Visit(AreaData data)
        {
            Name = data.Name;
            Description = data.Description;
            Created = data.Created;
        }

        public void Visit(PersistableActivitiesAreaData data)
        {
            Activities = data.Activities?
                .Select(activity => new ActivityViewModel(activity))
                .ToList();
        }
    }
}
