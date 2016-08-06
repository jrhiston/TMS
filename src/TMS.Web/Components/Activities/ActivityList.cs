using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMS.Layer.Readers;
using TMS.ModelLayer.Activities;
using TMS.ModelLayer.Areas;
using TMS.ViewModelLayer.Models.Activities;

namespace TMS.Web.Components.Activities
{
    public class ActivityList : ViewComponent
    {
        private readonly IReader<ActivityFilterData, IEnumerable<Activity>> _areaActivityReader;

        public ActivityList(IReader<ActivityFilterData, IEnumerable<Activity>> areaActivityReader)
        {
            _areaActivityReader = areaActivityReader;
        }

        public async Task<IViewComponentResult> InvokeAsync(ActivityListFilterData data)
        {
            var activities = await Task.Run(() => 
            {
                return _areaActivityReader.Read(new ActivityFilterData
                {
                    AreaKey = new AreaKey(data.AreaId)
                });
            });

            var activityViewModels = activities
                .SelectMany(item => item)
                .Select(activity => (ActivityListItemViewModel) activity.Accept(new ActivityListItemViewModel()));

            return View(activityViewModels);
        }
    }
}
