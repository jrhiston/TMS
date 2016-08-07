using System.ComponentModel.DataAnnotations.Schema;
using TMS.Database.Entities.Activities;

namespace TMS.Database.Entities.Tags
{
    [Table("TagActivity")]
    public class TagActivityEntity
    {
        public long TagId { get; set; }
        public TagEntity Tag { get; set; }

        public long ActivityId { get; set; }
        public ActivityEntity Activity { get; set; }
    }
}
