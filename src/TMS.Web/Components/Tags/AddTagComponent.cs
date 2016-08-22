using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMS.Layer.Readers;
using TMS.ModelLayer.Tags;
using TMS.ViewModelLayer.Models.Tags;

namespace TMS.Web.Components.Tags
{
    public class AddTagComponent : ViewComponent
    {
        private readonly IReader<TagFilterData, IEnumerable<Tag>> _tagReader;

        public AddTagComponent(IReader<TagFilterData, IEnumerable<Tag>> tagReader)
        {
            _tagReader = tagReader;
        }
        
        public async Task<IViewComponentResult> InvokeAsync(AddTagData data)
        {
            var context = data.Context;
            if (context == null)
                throw new InvalidOperationException("Must provide a context to add a tag in");

            var objectId = data.ObjectId;
            if (objectId <= 0)
                throw new InvalidOperationException("Must provide an object id greater than 0");

            var tags = await Task.Run(() => context.GetTags(_tagReader, data));

            var model = new AddTagViewModel
            {
                Action = context.ActionName,
                Controller = context.ControllerName,
                ObjectId = data.ObjectId,
                Tags = tags.Any() ? new SelectList(tags.Single().Select(t => (TagViewModel) t.Accept(new TagViewModel())), "Identifier", "Name") : null
            };

            return View(model);
        }
    }
}
