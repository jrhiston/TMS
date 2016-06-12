using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TMS.Database.Entities.PeopleAreas;
using TMS.Layer.Attributes;
using TMS.ModelLayerInterface.People;

namespace TMS.Database.Entities.People
{
    [Table("Person")]
    [LinkedTo(typeof(IPerson))]
    public class PersonEntity
    {
        [Key]
        public long Id { get; set; }

        [MaxLength(255)]
        [Required]
        public string FirstName { get; set; }

        [MaxLength(255)]
        [Required]
        public string LastName { get; set; }

        [MaxLength(255)]
        [Required]
        public string UserName { get; set; }

        [MaxLength(255)]
        [Required]
        public string PasswordHash { get; set; }

        public List<PeopleAreasEntity> PersonAreas { get; set; }
    }
}
