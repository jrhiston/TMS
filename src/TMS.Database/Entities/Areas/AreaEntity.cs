﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using TMS.Database.Entities.Activities;
using TMS.Database.Entities.People;
using TMS.Database.Entities.PeopleAreas;
using TMS.Layer.Visitors;
using TMS.ModelLayer.TMS.ModelLayerInterface.Areas;
using TMS.ModelLayerInterface.Areas.Data;
using TMS.ModelLayerInterface.Areas.Decorators;
using TMS.ModelLayerInterface.People.Decorators;

namespace TMS.Database.Entities.Areas
{
    [Table("Area")]
    public class AreaEntity : IVisitor<AreaData>, IVisitor<PersistableAreaData>, IVisitor<AreaWithPeopleData>
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

        internal void Accept(AreaEntity area)
        {
            Name = area.Name;
            Description = area.Description;
            Created = area.Created;
        }

        internal void Accept(IArea persistableArea) => persistableArea.Accept(() => this);

        public void Visit(AreaData data)
        {
            Name = data.Name;
            Description = data.Description;
            Created = data.Created;
        }

        public void Visit(PersistableAreaData data)
        {
            Id = data.AreaKey?.Identifier ?? 0;
        }

        public void Visit(AreaWithPeopleData data)
        {
            var people = data.People;
            if (people != null)
            {
                foreach (var person in people)
                {
                    AreaPersons = people.Select(CreatePeopleAreasEntity).ToList();
                }
            }
        }

        private PeopleAreasEntity CreatePeopleAreasEntity(IPersistablePerson person)
        {
            var personEntity = new PersonEntity();

            personEntity.Accept(person);

            return new PeopleAreasEntity
            {
                AreaId = Id,
                PersonId = personEntity.Id
            };
        }
    }
}
