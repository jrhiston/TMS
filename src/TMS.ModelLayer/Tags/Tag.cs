using System;
using TMS.Layer.ModelObjects;
using TMS.ModelLayerInterface.Tags;
using TMS.ModelLayerInterface.Tags.Data;

namespace TMS.ModelLayer.Tags
{
    public class Tag : ModelObjectBase<TagData>, ITag
    {
        private string _name;
        private string _description;
        private DateTime _created;
        private bool _canSetOnActivity;
        
        public Tag(TagData tag)
        {
            _name = tag.Name;
            _description = tag.Description;
            _created = tag.Created;
            _canSetOnActivity = tag.CanSetOnActivity;
        }

        protected override TagData GetData() => new TagData
        {
            CanSetOnActivity = _canSetOnActivity,
            Created = _created,
            Description = _description,
            Name = _name
        };
    }
}
