using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMS.Layer.Readers;
using TMS.ModelLayer.Tags;
using TMS.ViewModelLayer.Models.Tags;

namespace TMS.Web.Components.Tags
{
    public class AddTag : ViewComponent
    {
        private readonly IReader<TagFilterData, IEnumerable<Tag>> _tagReader;

        public AddTag(IReader<TagFilterData, IEnumerable<Tag>> tagReader)
        {
            _tagReader = tagReader;
        }


        public async Task<IViewComponentResult> InvokeAsync(CreateTagData data)
        {
            var tags = await Task.Run(() => _tagReader.Read(new TagFilterData
            {
                CanSetOnActivity = data.CanSetOnActivity
            }));

            var model = new AddTagViewModel
            {
                Action = data.Action,
                Controller = data.Controller,
                ObjectId = data.ObjectId,
                Tags = tags.Any() ? new SelectList(tags.Single().Select(t => (TagViewModel) t.Accept(new TagViewModel())), "Identifier", "Name") : null
            };

            return View(model);
        }
    }
}
