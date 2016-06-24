using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TMS.Layer.Factories;
using TMS.Layer.Readers;
using TMS.ModelLayerInterface.Activities.Data;
using TMS.ModelLayerInterface.Activities.Decorators;
using TMS.ModelLayerInterface.Areas;
using TMS.ModelLayerInterface.Areas.Data;
using TMS.ViewModelLayer.Models.Activities;

namespace TMS.Web.Components.Activities
{
    public class ActivityList : ViewComponent
    {
        private readonly IReader<ActivityFilterData, IEnumerable<IPersistableActivity>> _areaActivityReader;
        private readonly IFactory<AreaKeyData, IAreaKey> _areaKeyFactory;

        public ActivityList(IReader<ActivityFilterData, IEnumerable<IPersistableActivity>> areaActivityReader,
            IFactory<AreaKeyData, IAreaKey> areaKeyFactory)
        {
            _areaActivityReader = areaActivityReader;
            _areaKeyFactory = areaKeyFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(ActivityListFilterData data)
        {

            var areaKey = _areaKeyFactory.Create(new AreaKeyData
            {
                Identifier = data.AreaId
            });

            var activities = await Task.Run(() => 
            {
                return _areaActivityReader.Read(new ActivityFilterData
                {
                    AreaKey = areaKey
                });
            });

            var activityViewModels = activities
                .SelectMany(item => item)
                .Select(activity => new ActivityListItemViewModel(activity));

            return View(activityViewModels);
        }
    }
}
