using System;
using System.Linq;
using TMS.Layer.Creators;
using TMS.Layer.Persistence;
using TMS.Layer.Readers;
using TMS.ModelLayer.Tags;
using TMS.ViewModelLayer.Models.Tags;

namespace TMS.ApplicationLayer.Tags
{
    public class TagForTagCreator : ICreator<AddTagToTagViewModel>
    {
        private readonly IWriter<Tag, TagKey> _tagWriter;
        private readonly IReader<TagKey, Tag> _tagReader;

        public TagForTagCreator(IReader<TagKey, Tag> tagReader,
            IWriter<Tag, TagKey> tagWriter)
        {
            _tagReader = tagReader;
            _tagWriter = tagWriter;
        }

        public void Create(AddTagToTagViewModel data)
        {
            var existingTag = _tagReader.Read(new TagKey(data.TagId));

            if (!existingTag.Any())
                throw new InvalidOperationException($"Tag does not exist for id {data.TagId}");

            var tag = existingTag.Single();

            var tags = tag.OfType<Tag>();

            // Don't do anything if tag already exists.
            if (tags.Any(t => t.OfType<TagKey>().Single().Identifier == data.TagToAddId))
                return;

            var tagToAdd = _tagReader.Read(new TagKey(data.TagToAddId));

            if (!tagToAdd.Any())
                throw new InvalidOperationException("Tag to add does not exist");

            _tagWriter.Save(new Tag(tag.Append(new ParentTag(tagToAdd.Single())).ToArray()));
        }
    }
}
