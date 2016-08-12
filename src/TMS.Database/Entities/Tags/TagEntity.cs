using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TMS.Database.Entities.People;

namespace TMS.Database.Entities.Tags
{
    [Table("Tag")]
    public class TagEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public bool CanSetOnActivity { get; set; }
        public DateTime Created { get; set; }
        public bool Reusable { get; set; }

        public long AuthorId { get; set; }
        public PersonEntity Author { get; set; }

        public ICollection<TagToTagEntity> ParentTags { get; set; }
        public ICollection<TagToTagEntity> ChildTags { get; set; }

        public ICollection<TagActivityEntity> Activities { get; set; }

        public TagEntity()
        {
            Activities = new HashSet<TagActivityEntity>();
            ParentTags = new HashSet<TagToTagEntity>();
            ChildTags = new HashSet<TagToTagEntity>();
        }
    }
}
