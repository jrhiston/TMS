using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TMS.Layer.Visitors;
using TMS.ModelLayerInterface.Tags;
using TMS.ModelLayerInterface.Tags.Data;

namespace TMS.Web.Models.Tags
{
    public class TagViewModel : IVisitor<TagData>, IVisitor<PersistableTagData>, IVisitor<TaggableTagData>, IVisitor<ReusableTagData>
    {
        public long Identifier { get; set; }

        [Display(Name = "Created")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Created { get;  set; }
        
        [Display(Name = "Description")]
        public string Description { get;  set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get;  set; }

        [Required]
        [Display(Name = "Can set on activity?")]
        public bool CanSetOnActivity { get; set; }

        public bool Reusable { get; set; }

        public IList<TagViewModel> Tags { get; set; }

        public IList<TagViewModel> NonReusableTags { get; set; }

        public IList<TagViewModel> RemovedTags { get; set; }

        public bool Deleted { get; set; }

        public TagViewModel()
        {

        }

        public TagViewModel(ITag tag)
        {
            tag.Accept(() => this);
        }

        //internal IPersistableTag MapToModel(IFactory<TagData, ITag> tagFactory, IPersonKey ownerKey)
        //{
        //    var tagObject = tagFactory.Create(new TagData
        //    {
        //        Name = Name,
        //        CanSetOnActivity = CanSetOnActivity,
        //        Created = Created.HasValue ? Created.Value : DateTime.UtcNow,
        //        Description = Description
        //    });

        //    var tagsToPersist = GetListOfTagsFromActivityInformation(tagFactory, ownerKey);
        //    var reusableTag = tagFactory.CreateReusableTag(tagObject, Reusable);
        //    var deletedTag = tagFactory.CreateDeletedTag(reusableTag, Deleted);
        //    var ownedTag = tagFactory.CreateOwnedTag(deletedTag, ownerKey);

        //    var persistableTag = tagFactory.GetPersistableTag(ownedTag, tagFactory.GetTagKeyObject(Identifier));
        //    var taggableTag = tagFactory.GetTaggableTag(persistableTag, tagsToPersist);

        //    return taggableTag;
        //}

        //private List<ITag> GetListOfTagsFromActivityInformation(ITagFactory tagFactory, IPersonKey ownerKey)
        //{
        //    var tags = Tags;
        //    var nonReusableTags = NonReusableTags;
        //    var removedTags = RemovedTags;

        //    var tagsToPersist = new List<ITag>();

        //    if (tags != null)
        //    {
        //        foreach (var tag in tags)
        //        {
        //            tag.Reusable = true;

        //            var modelTag = tag.MapToModel(tagFactory, ownerKey);
        //            tagsToPersist.Add(modelTag);
        //        }
        //    }

        //    if (nonReusableTags != null)
        //    {
        //        foreach (var tag in nonReusableTags)
        //        {
        //            if (tag.Created == null)
        //            {
        //                tag.Created = DateTime.UtcNow;
        //            }

        //            tag.Reusable = false;
        //            tag.CanSetOnActivity = true;

        //            var modelTag = tag.MapToModel(tagFactory, ownerKey);
        //            tagsToPersist.Add(modelTag);
        //        }
        //    }

        //    if (removedTags != null)
        //    {
        //        foreach (var removedTag in removedTags)
        //        {
        //            removedTag.Deleted = true;

        //            var modelTag = removedTag.MapToModel(tagFactory, ownerKey);
        //            tagsToPersist.Add(modelTag);
        //        }
        //    }

        //    return tagsToPersist;
        //}

        public void Visit(ReusableTagData data)
        {
            Reusable = data.Reusable;
        }

        public void Visit(TaggableTagData data)
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

        public void Visit(PersistableTagData data)
        {
            Identifier = data.Key.Identifier;
        }

        public void Visit(TagData data)
        {
            Description = data.Description;
            Created = data.Created;
            Name = data.Name;
            CanSetOnActivity = data.CanSetOnActivity;
        }
    }
}