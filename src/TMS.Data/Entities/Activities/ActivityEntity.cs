using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TMS.Data.Entities.Activities.Comments;
using TMS.Data.Entities.Areas;
using TMS.Data.Entities.People;
using TMS.Data.Entities.Tags;

namespace TMS.Data.Entities.Activities
{
    [Table("Activity")]
    public class ActivityEntity
    {
        [Key]
        public long Id { get; set; }

        [MaxLength(255)]
        [Required]
        public string Title { get; set; }

        [Required]
        public DateTime Created { get; set; }
        
        public DateTime DeliveryTime { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }

        [Required]
        public long OwnerId { get; set; }
        public PersonEntity Owner { get; set; }

        [Required]
        public long AreaId { get; set; }
        public AreaEntity Area { get; set; }

        public ICollection<TagActivityEntity> Tags { get; set; }

        public ICollection<ActivityCommentEntity> Comments { get; set; }

        public ActivityEntity()
        {
            Tags = new HashSet<TagActivityEntity>();
            Comments = new HashSet<ActivityCommentEntity>();
        }
    }
}
