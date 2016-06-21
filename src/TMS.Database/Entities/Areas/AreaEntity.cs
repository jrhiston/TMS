using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TMS.Database.Entities.Activities;
using TMS.Database.Entities.PeopleAreas;
using TMS.Layer.Visitors;
using TMS.ModelLayerInterface.Areas.Data;
using TMS.ModelLayerInterface.Areas.Decorators;

namespace TMS.Database.Entities.Areas
{
    [Table("Area")]
    public class AreaEntity : IVisitor<AreaData>
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

        internal void Accept(IPersistableArea persistableArea) => persistableArea.Accept(() => this);

        public void Visit(AreaData data)
        {
            Name = data.Name;
            Description = data.Description;
            Created = data.Created;
        }
    }
}
