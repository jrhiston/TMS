using System.Collections.Generic;
using System.Linq;
using TMS.Layer;
using TMS.Layer.Readers;
using TMS.Layer.State;
using TMS.ModelLayer.Tags;

namespace TMS.ViewModelLayer.Models.Tags.AddTagContextTypes
{
    public abstract class AddTagContextTypeBase : StateObjectBase<AddTagContextTypeBase, string>
    {
        public abstract string ControllerName { get; }
        public abstract string ActionName { get; }

        public AddTagContextTypeBase(string identifier) : base(identifier)
        {
        }

        public abstract Maybe<IEnumerable<Tag>> GetTags(
            IReader<TagFilterData, IEnumerable<Tag>> tagReader,
            AddTagData data);

        protected static long[] GetExcludedTagIds(
            IReader<TagFilterData, IEnumerable<Tag>> tagReader,
            TagFilterData filterData,
            long id)
        {
            var existingTags = tagReader.Read(filterData);

            // Exclude parent tags already on the tag.
            return existingTags.Any() 
                ? existingTags
                    .Single()
                    .SelectMany(t => t.OfType<TagKey>())
                    .Select(k => k.Identifier)
                    .ToArray() 
                : null;
        }

        protected sealed override void InitialiseEntries()
        {
            AddEntry(new AddTagToTagContextType());
            AddEntry(new AddTagToActivityContextType());
        }
    }
}
