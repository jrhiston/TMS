using System;
using System.Collections.Generic;
using System.Linq;
using TMS.ApplicationLayer.Tags.Data;
using TMS.Layer.Exceptions;
using TMS.Layer.Initialisers;
using TMS.Layer.Readers;
using TMS.ModelLayer.Tags;
using TMS.ViewModelLayer.Models.Tags;
using TMS.ViewModelLayer.Models.Tags.Pages;

namespace TMS.ApplicationLayer.Tags
{
    public class TagsPageModelInitialiser : IInitialiser<TagsPageModelInitialiserData, TagsPageModel>
    {
        private readonly IReader<TagFilterData, IEnumerable<Tag>> _tagReader;

        public TagsPageModelInitialiser(IReader<TagFilterData, IEnumerable<Tag>> tagReader)
        {
            _tagReader = tagReader;
        }

        public TagsPageModel Initialise(TagsPageModelInitialiserData data)
        {
            if (data == null)
                throw new MustProvideInitialiserDataException("Must provide data to initialise the model with.");

            if (data.CurrentUserKey == null)
                throw new MustProvideInitialiserDataException("Must provide a current user to initialise the area page model.");

            var tags = _tagReader.Read(new TagFilterData());

            if (tags == null)
                throw new InvalidOperationException("Failed to retrieve a list of areas for the given user");
            
            return new TagsPageModel
            {
                Tags = tags.SelectMany(item => item)
                    .Select(area => area.Accept(new TagListItemViewModel()))
                    .OfType<TagListItemViewModel>()
                    .ToList()
            };
        }
    }
}
