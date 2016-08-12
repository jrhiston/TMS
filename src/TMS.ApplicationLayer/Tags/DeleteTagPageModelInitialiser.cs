using System;
using System.Linq;
using TMS.ApplicationLayer.Tags.Data;
using TMS.Layer.Initialisers;
using TMS.Layer.Readers;
using TMS.ModelLayer.Tags;
using TMS.ViewModelLayer.Models.Tags;
using TMS.ViewModelLayer.Models.Tags.Pages;

namespace TMS.ApplicationLayer.Tags
{
    public class DeleteTagPageModelInitialiser : IInitialiser<DeleteTagPageModelInitialiserData, DeleteTagPageModel>
    {
        private readonly IReader<TagKey, Tag> _tagReader;

        public DeleteTagPageModelInitialiser(IReader<TagKey, Tag> tagReader)
        {
            _tagReader = tagReader;
        }

        public DeleteTagPageModel Initialise(DeleteTagPageModelInitialiserData data)
        {
            var tagViewModel = _tagReader
                .Read(new TagKey(data.TagId))
                .Select(t => t.Accept(new TagViewModel()))
                .OfType<TagViewModel>()
                .FirstOrDefault();

            if (tagViewModel == null)
                throw new InvalidOperationException($"Failed to find activity matching the given id {data.TagId}");

            return new DeleteTagPageModel
            {
                Id = tagViewModel.Identifier,
                Name = tagViewModel.Name
            };
        }
    }
}
