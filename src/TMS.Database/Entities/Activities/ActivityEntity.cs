using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TMS.Database.Entities.Areas;
using TMS.Database.Entities.People;
using TMS.Layer.Visitors;
using TMS.ModelLayerInterface.Activities;
using TMS.ModelLayerInterface.Activities.Data;
using TMS.ModelLayerInterface.Areas.Data;

namespace TMS.Database.Entities.Activities
{
    [Table("Activity")]
    public class ActivityEntity : IVisitor<ActivityData>, IVisitor<ActivityAreaData>, IVisitor<OwnedActivityData>
    {
        [Key]
        public long Id { get; set; }

        [MaxLength(255)]
        [Required]
        public string Title { get; set; }

        [Required]
        public DateTime Created { get; set; }
        
        public DateTime DeliveryTime { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }

        [Required]
        public long OwnerId { get; set; }
        public PersonEntity Owner { get; set; }

        [Required]
        public long AreaId { get; set; }
        public AreaEntity Area { get; set; }

        internal void Accept(ActivityEntity newEntity)
        {
            Title = newEntity.Title;
            Created = newEntity.Created;
            DeliveryTime = newEntity.DeliveryTime;
            Description = newEntity.Description;
            Owner = newEntity.Owner;
            AreaId = newEntity.AreaId;
            Area = newEntity.Area;
        }

        internal void Accept(IActivity activity) => activity.Accept(() => this);

        public void Visit(ActivityData data)
        {
            Title = data.Title;
            Description = data.Description;
            Created = data.Created;
        }

        public void Visit(ActivityAreaData data)
        {
            var areaEntity = new AreaEntity();
            areaEntity.Accept(data.Area);

            AreaId = areaEntity.Id;
        }

        public void Visit(OwnedActivityData data)
        {
            OwnerId = data.OwnerKey.Identifier;
        }
    }
}
