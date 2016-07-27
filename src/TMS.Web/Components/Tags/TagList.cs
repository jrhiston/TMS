using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMS.Layer.Factories;
using TMS.Layer.Readers;
using TMS.ModelLayerInterface.Activities;
using TMS.ModelLayerInterface.Activities.Data;
using TMS.ModelLayerInterface.Tags.Data;
using TMS.ModelLayerInterface.Tags.Decorators;
using TMS.ViewModelLayer.Models.Tags;

namespace TMS.Web.Components.Tags
{
    public class TagList : ViewComponent
    {
        private readonly IReader<TagFilterData, IEnumerable<IPersistableTag>> _tagReader;
        private readonly IFactory<ActivityKeyData, IActivityKey> _activityFactory;

        public TagList(IReader<TagFilterData, IEnumerable<IPersistableTag>> tagReader,
            IFactory<ActivityKeyData, IActivityKey> activityFactory)
        {
            _tagReader = tagReader;
            _activityFactory = activityFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(TagListFilterData data)
        {
            var activityKey = _activityFactory.Create(new ActivityKeyData { Identifier = data.ActivityId });

            var result = await Task.Run(() => _tagReader.Read(new TagFilterData { ActivityKey = activityKey }));

            var tagViewModels = result
                .SelectMany(item => item)
                .Select(tag => new TagListItemViewModel(tag));

            return View(tagViewModels);
        }
    }
}
