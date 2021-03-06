﻿using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMS.Layer.Readers;
using TMS.ModelLayer.Activities;
using TMS.ModelLayer.Tags;
using TMS.ViewModelLayer.Models.Tags;

namespace TMS.Web.Components.Tags
{
    public class TagList : ViewComponent
    {
        private readonly IReader<TagFilterData, IEnumerable<Tag>> _tagReader;

        public TagList(IReader<TagFilterData, IEnumerable<Tag>> tagReader)
        {
            _tagReader = tagReader;
        }

        public async Task<IViewComponentResult> InvokeAsync(TagListFilterData data)
        {
            var result = await Task.Run(() => _tagReader.Read(new TagFilterData
            {
                ActivityKey = data.ActivityId.HasValue ? new ActivityKey(data.ActivityId.Value) : null,
                ChildTagKey = data.ChildTagId.HasValue ? new TagKey(data.ChildTagId.Value) : null,
                Reusable = data.Reusable
            }));

            var tagViewModels = result
                .SelectMany(item => item)
                .Select(tag => (TagListItemViewModel) tag.Accept(new TagListItemViewModel()));

            return View(tagViewModels);
        }
    }
}
