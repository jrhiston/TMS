using System;
using System.Collections.Generic;
using System.Linq;
using TMS.Layer;
using TMS.Layer.Readers;
using TMS.ModelLayer.Tags;

namespace TMS.ViewModelLayer.Models.Tags.AddTagContextTypes
{
    public abstract class AddTagContextTypeBase
    {
        private static Dictionary<string, Func<AddTagContextTypeBase>> s_Instances = new Dictionary<string, Func<AddTagContextTypeBase>>();

        public abstract string ControllerName { get; }
        public abstract string ActionName { get; }
        public string Identifier { get; }

        public AddTagContextTypeBase(string identifier)
        {
            Identifier = identifier;
        }

        static AddTagContextTypeBase()
        {
            AddDictionaryEntry(new AddTagToTagContextType());
            AddDictionaryEntry(new AddTagToActivityContextType());
        }

        public static AddTagContextTypeBase CreateInstance(string id)
        {
            Func<AddTagContextTypeBase> function;

            if (s_Instances.TryGetValue(id, out function))
            {
                return function.Invoke();
            }

            throw new InvalidOperationException($"No context found for the given id {id}");
        }

        public static void AddDictionaryEntry(AddTagContextTypeBase addTagToTagContextType) => s_Instances.Add(addTagToTagContextType.Identifier, () => addTagToTagContextType);

        public abstract Maybe<IEnumerable<Tag>> GetTags(IReader<TagFilterData, IEnumerable<Tag>> tagReader, AddTagData data);

        protected static long[] GetExcludedTagIds(IReader<TagFilterData, IEnumerable<Tag>> tagReader, long id)
        {
            var existingTags = tagReader.Read(new TagFilterData
            {
                ChildTagKey = new TagKey(id)
            });

            // Exclude child tags already on the tag.
            return existingTags.Any() 
                ? existingTags.Single()
                    .OfType<TagKey>()
                    .Select(k => k.Identifier)
                    .ToArray() 
                : new long[0];
        }
    }
}
