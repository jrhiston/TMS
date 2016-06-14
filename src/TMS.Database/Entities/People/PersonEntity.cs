using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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
    public class PersonEntity : IdentityUser<long>
    {
        [MaxLength(255)]
        [Required]
        public string FirstName { get; set; }

        [MaxLength(255)]
        [Required]
        public string LastName { get; set; }

        public List<PeopleAreasEntity> PersonAreas { get; set; }
    }
}
