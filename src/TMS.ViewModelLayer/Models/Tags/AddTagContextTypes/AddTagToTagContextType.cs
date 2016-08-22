using System.Collections.Generic;
using System.Linq;
using TMS.Layer;
using TMS.Layer.Readers;
using TMS.ModelLayer.Tags;

namespace TMS.ViewModelLayer.Models.Tags.AddTagContextTypes
{
    public class AddTagToTagContextType : AddTagContextTypeBase
    {
        public const string Id = "{6DF0E110-0EAF-4D87-A8E7-109403E63492}";

        public override string ActionName => "CreateForTag";
        public override string ControllerName => "Tags";

        public AddTagToTagContextType() : base(Id)
        {
        }

        public override Maybe<IEnumerable<Tag>> GetTags(IReader<TagFilterData, IEnumerable<Tag>> tagReader, AddTagData data)
        {
            var filterData = new TagFilterData
            {
                Reusable = true,
                ExcludedTagIds = GetExcludedTagIds(tagReader, data.ObjectId)
                    .Append(data.ObjectId)
                    .ToArray()
            };

            return tagReader.Read(filterData);
        }
    }
}
