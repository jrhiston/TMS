using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TMS.Data.Entities.PeopleAreas;
using TMS.Data.Entities.Tags;
using TMS.Data.Entities.Activities.Comments;

namespace TMS.Data.Entities.People
{
    [Table("Person")]
    public sealed class PersonEntity : IdentityUser<long>
    {
        [MaxLength(255)]
        public string FirstName { get; set; }

        [MaxLength(255)]
        public string LastName { get; set; }

        public ICollection<PeopleAreasEntity> PersonAreas { get; set; }

        [InverseProperty("Author")]
        public ICollection<TagEntity> AuthoredTags { get; set; }

        [InverseProperty("Author")]
        public ICollection<ActivityCommentEntity> AuthoredActivityComments { get; set; }

        public PersonEntity()
        {
            PersonAreas = new HashSet<PeopleAreasEntity>();
            AuthoredTags = new HashSet<TagEntity>();
            AuthoredActivityComments = new HashSet<ActivityCommentEntity>();
        }
    }
}
