using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TMS.Database.Entities.Areas;
using TMS.Database.Entities.People;

namespace TMS.Database.Entities.Activities
{
    [Table("Activity")]
    public class ActivityEntity
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(255)]
        [Required]
        public string Title { get; set; }

        [Required]
        public DateTime Created { get; set; }
        
        public DateTime DeliveryTime { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }

        [Required]
        public PersonEntity Owner { get; set; }

        public long AreaId { get; set; }
        public AreaEntity Area { get; set; }
    }
}
