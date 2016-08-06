using System;
using System.Linq;
using TMS.ModelLayer;
using TMS.ModelLayer.Activities;
using TMS.ModelLayer.Areas;

namespace TMS.ViewModelLayer.Models.Activities
{
    public class ActivityListItemViewModel : ActivityVisitorBase
    {
        public long Id { get; private set; }
        public DateTime Created { get; private set; }
        public string Description { get; private set; }
        public string Name { get; private set; }
        public long AreaId { get; set; }

        public override IActivityVisitor Visit(ActivityKey data)
        {
            Id = data.Identifier;
            return this;
        }

        public override IActivityVisitor Visit(CreationDate data)
        {
            Created = data.Value;
            return this;
        }

        public override IActivityVisitor Visit(Description data)
        {
            Description = data.Value;
            return this;
        }

        public override IActivityVisitor Visit(Name data)
        {
            Name = data.Value;
            return this;
        }

        public override IActivityVisitor Visit(AreaKey data)
        {
            AreaId = data.Identifier;
            return this;
        }
    }
}
