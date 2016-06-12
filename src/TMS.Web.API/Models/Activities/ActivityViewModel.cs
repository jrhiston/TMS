using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TMS.Layer.Visitors;
using TMS.ModelLayerInterface.Activities;
using TMS.ModelLayerInterface.Activities.Data;
using TMS.Web.API.Models.Tags;

namespace TMS.Web.API.Models.Activities
{
    public class ActivityViewModel : IVisitor<PersistableActivityData>, IVisitor<ActivityData>, IVisitor<TaggableActivityData>
    {
        public long Identifier { get; set; }

        public long OwnerIdentifier { get; set; }

        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Created")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CreationDate { get; set; }

        public IList<TagViewModel> Tags { get; set; }

        public IList<TagViewModel> NonReusableTags { get; set; }

        public IList<TagViewModel> RemovedTags { get; set; }

        public ActivityViewModel()
        {

        }

        public ActivityViewModel(IActivity activity)
        {
            if (activity == null)
                throw new ArgumentNullException(nameof(activity));

            activity.Accept(() => this);
        }

        public void Visit(TaggableActivityData data)
        {
            Tags = new List<TagViewModel>();
            NonReusableTags = new List<TagViewModel>();

            foreach (var tag in data.Tags)
            {
                var tagViewModel = new TagViewModel(tag);
                if (tagViewModel.Reusable)
                {
                    Tags.Add(tagViewModel);
                }
                else
                {
                    NonReusableTags.Add(tagViewModel);
                }
            }
        }

        public void Visit(ActivityData data)
        {
            CreationDate = data.CreationDate;
            Description = data.Description;
            Title = data.Title;
        }

        public void Visit(PersistableActivityData data)
        {
            Identifier = data.Key.Identifier;
        }
    }
}