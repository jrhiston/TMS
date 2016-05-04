using System.Collections.Generic;
using System.Linq;
using TMS.Layer.Factories;
using TMS.Layer.Readers;
using TMS.ModelLayer.TMS.ModelLayerInterface.Areas;
using TMS.ModelLayerInterface.Activities;
using TMS.ModelLayerInterface.Areas;
using TMS.ModelLayerInterface.Areas.Data;
using TMS.Web.Models.Activities;

namespace TMS.Web.Models.Areas
{
    public class AreaActivitiesViewModel
    {
        public AreaViewModel Area { get; set; }
        public List<ActivityAreaViewModel> Activities { get; set; }

        public AreaActivitiesViewModel(IArea area, 
            IReader<IAreaKey, IEnumerable<IActivity>> activityReader,
            IFactory<AreaKeyData, IAreaKey> areaKeyFactory)
        {
            Area = new AreaViewModel(area);

            if (Area.AreaId.HasValue)
            {
                Activities = activityReader.Read(areaKeyFactory.Create(new AreaKeyData
                {
                    Identifier = Area.AreaId.Value
                }))
                .Select(activity => new ActivityAreaViewModel(activity))
                .ToList();
            }
        }
    }
}