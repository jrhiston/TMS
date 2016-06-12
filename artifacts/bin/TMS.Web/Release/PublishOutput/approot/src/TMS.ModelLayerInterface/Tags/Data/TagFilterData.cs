using TMS.Layer.Data;
using TMS.ModelLayerInterface.Activities;
using TMS.ModelLayerInterface.People;

namespace TMS.ModelLayerInterface.Tags.Data
{
    public class TagFilterData : IData
    {
        public IActivityKey ActivityKey { get; set; }

        public ITagKey ChildTagKey { get; set; }

        public IPersonKey CreatorKey { get; set; }

        public string TagName { get; set; }

        public bool? Reusable { get; set; }

        public bool? CanSetOnActivity { get; set; }

        public ITagKey ParentTagKey { get; set; }
    }
}