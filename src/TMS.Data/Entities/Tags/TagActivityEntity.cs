using System.ComponentModel.DataAnnotations.Schema;
using TMS.Data.Entities.Activities;

namespace TMS.Data.Entities.Tags
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
