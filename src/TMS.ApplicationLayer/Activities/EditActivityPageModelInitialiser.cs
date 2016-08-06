using System;
using System.Linq;
using TMS.ApplicationLayer.Activities.Data;
using TMS.Layer.Initialisers;
using TMS.Layer.Readers;
using TMS.ModelLayer.Activities;
using TMS.ViewModelLayer.Models.Activities;
using TMS.ViewModelLayer.Models.Activities.Pages;

namespace TMS.ApplicationLayer.Activities
{
    public class EditActivityPageModelInitialiser : IInitialiser<EditActivityPageModelInitialiserData, EditActivityPageModel>
    {
        private readonly IReader<ActivityKey, Activity> _areaReader;

        public EditActivityPageModelInitialiser(IReader<ActivityKey, Activity> areaReader)
        {
            _areaReader = areaReader;
        }

        public EditActivityPageModel Initialise(EditActivityPageModelInitialiserData data)
        {
            var area = _areaReader.Read(new ActivityKey(data.ActivityId));

            if (!area.Any())
                throw new InvalidOperationException($"Failed to find activity for given identifier {data.ActivityId}");

            var activityViewModel = (ActivityViewModel) area.Single().Accept(new ActivityViewModel());

            return new EditActivityPageModel
            {
                Id = activityViewModel.Id,
                AreaId = activityViewModel.AreaId,
                Name = activityViewModel.Title,
                Description = activityViewModel.Description,
                Tags = activityViewModel.Tags
            };
        }
    }
}
