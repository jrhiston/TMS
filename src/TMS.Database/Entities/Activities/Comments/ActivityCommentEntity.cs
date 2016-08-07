using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TMS.Database.Entities.People;

namespace TMS.Database.Entities.Activities.Comments
{
    [Table("ActivityComment")]
    public class ActivityCommentEntity
    {
        public long Id { get; set; }

        public long ActivityId { get; set; }
        public ActivityEntity Activity { get; set; }

        [Required]
        public string Description { get; set; }

        public long AuthorId { get; set; }
        public PersonEntity Author { get; set; }

        public DateTime Created { get; set; }
    }
}
