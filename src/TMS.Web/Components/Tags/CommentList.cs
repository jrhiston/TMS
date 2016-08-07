using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMS.Layer.Readers;
using TMS.ModelLayer.Activities;
using TMS.ModelLayer.People;
using TMS.ModelLayer.Tags;
using TMS.ViewModelLayer.Models.Tags;

namespace TMS.Web.Components.Tags
{
    public class CommentList : ViewComponent
    {
        private readonly IReader<PersonKey, Person> _personReader;
        private readonly IReader<TagFilterData, IEnumerable<Tag>> _tagReader;

        public CommentList(IReader<TagFilterData, IEnumerable<Tag>> tagReader,
            IReader<PersonKey, Person> personReader)
        {
            _tagReader = tagReader;
            _personReader = personReader;
        }

        public async Task<IViewComponentResult> InvokeAsync(CommentListFilterData data)
        {
            var result = await Task.Run(() => _tagReader.Read(new TagFilterData
            {
                ActivityKey = new ActivityKey(data.ActivityId),
                Reusable = false
            }));

            var comments = result
                .SelectMany(item => item)
                .Select(tag => (CommentListItemViewModel)tag.Accept(new CommentListItemViewModel()))
                .ToList();

            foreach (var comment in comments)
            {
                comment.ParentId = data.ActivityId;

                var creator = _personReader.Read(new PersonKey(comment.CreatorId));

                if (creator != null && creator.Any())
                    comment.Creator = creator.Single().OfType<UserName>().Single().Value;
            }

            return View(comments);
        }
    }
}
