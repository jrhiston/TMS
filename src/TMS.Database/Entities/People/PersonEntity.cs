using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TMS.Database.Entities.PeopleAreas;

namespace TMS.Database.Entities.People
{
    [Table("Person")]
    public sealed class PersonEntity : IdentityUser<long>
    {
        [MaxLength(255)]
        public string FirstName { get; set; }

        [MaxLength(255)]
        public string LastName { get; set; }

        public ICollection<PeopleAreasEntity> PersonAreas { get; set; }

        public PersonEntity()
        {
            PersonAreas = new HashSet<PeopleAreasEntity>();
        }
    }
}
