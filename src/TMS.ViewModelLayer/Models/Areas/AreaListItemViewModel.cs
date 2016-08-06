using System;
using TMS.ModelLayer;
using TMS.ModelLayer.Areas;

namespace TMS.ViewModelLayer.Models.Areas
{
    public class AreaListItemViewModel : AreaVisitorBase
    {
        public long Id { get; set; }
        public DateTime Created { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }

        public override IAreaVisitor Visit(AreaKey areaKey)
        {
            Id = areaKey.Identifier;
            return this;
        }

        public override IAreaVisitor Visit(CreationDate creationDate)
        {
            Created = creationDate.Value;
            return this;
        }

        public override IAreaVisitor Visit(Description description)
        {
            Description = description.Value;
            return this;
        }

        public override IAreaVisitor Visit(Name name)
        {
            Name = name.Value;
            return this;
        }
    }
}
