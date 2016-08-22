using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TMS.Data.Entities.Activities;
using TMS.Data.Entities.PeopleAreas;

namespace TMS.Data.Entities.Areas
{
    [Table("Area")]
    public class AreaEntity
    {
        [Key]
        public long Id { get; set; }

        [MaxLength(255)]
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime Created { get; set; }

        public ICollection<PeopleAreasEntity> AreaPersons { get; set; }

        public ICollection<ActivityEntity> Activities { get; set; }

        public AreaEntity()
        {
            AreaPersons = new HashSet<PeopleAreasEntity>();
            Activities = new HashSet<ActivityEntity>();
        }
    }
}
