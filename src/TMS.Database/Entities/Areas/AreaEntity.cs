using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TMS.Database.Entities.Activities;
using TMS.Database.Entities.PeopleAreas;

namespace TMS.Database.Entities.Areas
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

        public List<PeopleAreasEntity> AreaPersons { get; set; }

        public List<ActivityEntity> Activities { get; set; }
    }
}
