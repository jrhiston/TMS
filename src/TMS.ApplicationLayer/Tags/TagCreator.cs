using System.Collections.Generic;
using System.Linq;
using TMS.Layer.Creators;
using TMS.Layer.Persistence;
using TMS.Layer.Readers;
using TMS.ModelLayer;
using TMS.ModelLayer.People;
using TMS.ModelLayer.Tags;
using TMS.ModelLayer.Tags.CanSetOnActivities;
using TMS.ViewModelLayer.Models.Tags.Pages;

namespace TMS.ApplicationLayer.Tags
{
    public class TagCreator : ICreator<TagPageModelBase>
    {
        private readonly IWriter<Tag, TagKey> _tagWriter;
        private readonly IReader<TagKey, Tag> _reader;

        public TagCreator(IReader<TagKey, Tag> reader,
            IWriter<Tag, TagKey> tagWriter)
        {
            _reader = reader;
            _tagWriter = tagWriter;
        }

        public void Create(TagPageModelBase model)
        {
            var list = new List<ITagElement>
            {
                new Name(model.Name),
                new Description(model.Description),
                new PersonKey(model.AuthorId),
                model.CanSetOnActivity ? (CanSetOnActivityBase) new CanSetOnActivity() : new CanNotSetOnActivity()
            };

            if (model.TagId > 0)
            {
                var existingTag = _reader.Read(new TagKey(model.TagId)).Single();

                // Keep items not being modified.
                var existingItems = existingTag.Where(item => !(item is Name 
                    || item is Description 
                    || item is PersonKey 
                    || item is CanSetOnActivityBase));

                list.AddRange(existingItems);
            }
            else
            {
                list.Add(new CreationDate(model.Created));
            }

            _tagWriter.Save(new Tag(list.ToArray()));
        }
    }
}
