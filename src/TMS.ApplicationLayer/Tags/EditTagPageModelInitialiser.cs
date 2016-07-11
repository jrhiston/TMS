using System;
using System.Linq;
using TMS.ApplicationLayer.Exceptions;
using TMS.ApplicationLayer.Tags.Data;
using TMS.Layer.Exceptions;
using TMS.Layer.Factories;
using TMS.Layer.Initialisers;
using TMS.Layer.Readers;
using TMS.ModelLayerInterface.Tags;
using TMS.ModelLayerInterface.Tags.Data;
using TMS.ViewModelLayer.Models.Tags;
using TMS.ViewModelLayer.Models.Tags.Pages;

namespace TMS.ApplicationLayer.Tags
{
    public class EditTagPageModelInitialiser : IInitialiser<EditTagPageModelInitialiserData, EditTagPageModel>
    {
        private readonly IFactory<TagKeyData, ITagKey> _tagKeyFactory;
        private readonly IReader<ITagKey, ITag> _tagReader;

        public EditTagPageModelInitialiser(IReader<ITagKey, ITag> tagReader,
            IFactory<TagKeyData, ITagKey> tagKeyFactory)
        {
            _tagReader = tagReader;
            _tagKeyFactory = tagKeyFactory;
        }

        public EditTagPageModel Initialise(EditTagPageModelInitialiserData data)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data), "Must provide tag id to create an edit page model with.");
            if (data.TagId <= 0)
                throw new IdentifierNotSpecifiedException("Must provide an identifier greater than zero to edit a tag.");

            var tagKey = _tagKeyFactory.Create(new TagKeyData { Identifier = data.TagId });

            var tag = _tagReader
                .Read(tagKey)?
                .FirstOrDefault();

            if (tag == null)
                throw new ModelObjectNotFoundException($"Failed to find tag with id {data.TagId}");

            var tagViewModel = new TagViewModel(tag);

            return new EditTagPageModel
            {
                TagId = tagViewModel.Identifier,
                TagName = tagViewModel.Name,
                Created = tagViewModel.Created,
                CanSetOnActivity = tagViewModel.CanSetOnActivity,
                Description = tagViewModel.Description
            };
        }
    }
}
