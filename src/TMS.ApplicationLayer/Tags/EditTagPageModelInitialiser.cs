using System;
using System.Linq;
using TMS.ApplicationLayer.Exceptions;
using TMS.ApplicationLayer.Tags.Data;
using TMS.Layer.Exceptions;
using TMS.Layer.Initialisers;
using TMS.Layer.Readers;
using TMS.ModelLayer.Tags;
using TMS.ViewModelLayer.Models.Tags;
using TMS.ViewModelLayer.Models.Tags.Pages;

namespace TMS.ApplicationLayer.Tags
{
    public class EditTagPageModelInitialiser : IInitialiser<EditTagPageModelInitialiserData, EditTagPageModel>
    {
        private readonly IReader<TagKey, Tag> _tagReader;

        public EditTagPageModelInitialiser(IReader<TagKey, Tag> tagReader)
        {
            _tagReader = tagReader;
        }

        public EditTagPageModel Initialise(EditTagPageModelInitialiserData data)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data), "Must provide tag id to create an edit page model with.");
            if (data.TagId <= 0)
                throw new IdentifierNotSpecifiedException("Must provide an identifier greater than zero to edit a tag.");

            var tagKey = new TagKey(data.TagId);

            var tag = _tagReader
                .Read(tagKey)?
                .FirstOrDefault();

            if (tag == null)
                throw new ModelObjectNotFoundException($"Failed to find tag with id {data.TagId}");

            var tagViewModel = (TagViewModel)tag.Accept(new TagViewModel());

            return new EditTagPageModel
            {
                TagId = tagViewModel.Identifier,
                Name = tagViewModel.Name,
                Created = tagViewModel.Created,
                CanSetOnActivity = tagViewModel.CanSetOnActivity,
                Description = tagViewModel.Description,
                AuthorId = tagViewModel.AuthorId
            };
        }
    }
}
