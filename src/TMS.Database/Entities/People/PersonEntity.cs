using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TMS.Database.Entities.PeopleAreas;
using TMS.ModelLayerInterface.People.Decorators;
using TMS.Layer.Visitors;
using TMS.ModelLayerInterface.People.Data;

namespace TMS.Database.Entities.People
{
    [Table("Person")]
    public sealed class PersonEntity : IdentityUser<long>, IVisitor<PersistablePersonData>, IVisitor<PersonData>
    {
        [MaxLength(255)]
        public string FirstName { get; set; }

        [MaxLength(255)]
        public string LastName { get; set; }

        public List<PeopleAreasEntity> PersonAreas { get; set; }

        public void Visit(PersonData data)
        {
            FirstName = data.FirstName;
            LastName = data.LastName;
            UserName = data.UserName;
        }

        public void Visit(PersistablePersonData data)
        {
            Id = data.PersonKey?.Identifier ?? 0;
            PasswordHash = data.PasswordHash;
        }

        internal void Accept(IPersistablePerson person)
        {
            person.Accept(() => this);
        }
    }
}
