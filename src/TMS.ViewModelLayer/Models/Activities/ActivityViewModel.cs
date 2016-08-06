using System;
using System.Collections.Generic;
using System.Linq;
using TMS.ModelLayer;
using TMS.ModelLayer.Activities;
using TMS.ModelLayer.Areas;
using TMS.ModelLayer.Tags;
using TMS.ViewModelLayer.Models.Tags;

namespace TMS.ViewModelLayer.Models.Activities
{
    public class ActivityViewModel : ActivityVisitorBase
    {
        public long Id { get; private set; }
        public DateTime Created { get; private set; }
        public string Description { get; private set; }
        public string Title { get; private set; }
        public long AreaId { get; private set; }
        public List<TagViewModel> Tags { get; }

        public ActivityViewModel()
        {
            Tags = new List<TagViewModel>();
        }

        public override IActivityVisitor Visit(Name data)
        {
            Title = data.Value;
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

        public override IActivityVisitor Visit(ActivityKey data)
        {
            Id = data.Identifier;
            return this;
        }

        public override IActivityVisitor Visit(Tag data)
        {
            Tags.Add((TagViewModel)data.Accept(new TagViewModel()));
            return this;
        }

        public override IActivityVisitor Visit(AreaKey data)
        {
            AreaId = data.Identifier;
            return this;
        }
    }
}
