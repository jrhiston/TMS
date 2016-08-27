using System.Collections.Generic;
using System.Linq;
using TMS.Layer;
using TMS.Layer.Readers;
using TMS.ModelLayer.Activities;
using TMS.ModelLayer.Tags;

namespace TMS.ViewModelLayer.Models.Tags.AddTagContextTypes
{
    public class AddTagToActivityContextType : AddTagContextTypeBase
    {
        public const string Id = "{5767056B-DB70-40D1-903A-8A852F71B316}";

        public override string ActionName => "CreateForActivity";
        public override string ControllerName => "Tags";

        public AddTagToActivityContextType() : base(Id)
        {
        }
        
        public override Maybe<IEnumerable<Tag>> GetTags(
            IReader<TagFilterData, IEnumerable<Tag>> tagReader,
            AddTagData data) => tagReader.Read(new TagFilterData
        {
            Reusable = true,
            CanSetOnActivity = true,
            ExcludedTagIds = GetExcludedTagIds(tagReader, GetTagFilterData(data), data.ObjectId)?.ToArray()
        });

        private static TagFilterData GetTagFilterData(AddTagData data) => new TagFilterData
        {
            ActivityKey = new ActivityKey(data.ObjectId)
        };
    }
}
