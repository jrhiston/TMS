using TMS.Layer.Data;
using TMS.ModelLayer.Activities;
using TMS.ModelLayer.People;

namespace TMS.ModelLayer.Tags
{
    public class TagFilterData : IData
    {
        public ActivityKey ActivityKey { get; set; }

        public TagKey ChildTagKey { get; set; }

        public PersonKey CreatorKey { get; set; }

        public string TagName { get; set; }

        public bool? Reusable { get; set; }

        public bool? CanSetOnActivity { get; set; }

        public TagKey ParentTagKey { get; set; }

        public long[] ExcludedTagIds { get; set; }
    }
}