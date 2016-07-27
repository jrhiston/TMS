using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TMS.Database.Entities.Tags
{
    [Table("Tag")]
    public class TagEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool CanSetOnActivity { get; set; }
        public DateTime Created { get; set; }
        public bool Reusable { get; set; }

        public ICollection<TagActivityEntity> Activities { get; set; }

        public TagEntity()
        {
            Activities = new HashSet<TagActivityEntity>();
        }
    }
}
