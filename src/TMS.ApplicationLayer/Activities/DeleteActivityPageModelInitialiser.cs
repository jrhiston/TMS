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
    public class DeleteActivityPageModelInitialiser : IInitialiser<DeleteActivityPageModelInitialiserData, DeleteActivityPageModel>
    {
        private readonly IReader<ActivityKey, Activity> _areaReader;

        public DeleteActivityPageModelInitialiser(IReader<ActivityKey, Activity> areaReader)
        {
            _areaReader = areaReader;
        }

        public DeleteActivityPageModel Initialise(DeleteActivityPageModelInitialiserData data)
        {
            var areaViewModel = _areaReader
                .Read(new ActivityKey(data.ActivityId))
                .Select(activity => activity.Accept(new ActivityViewModel()))
                .OfType<ActivityViewModel>()
                .FirstOrDefault();

            if (areaViewModel == null)
                throw new InvalidOperationException($"Failed to find activity matching the given id {data.ActivityId}");

            return new DeleteActivityPageModel
            {
                Id = areaViewModel.Id,
                Name = areaViewModel.Title,
                AreaId = areaViewModel.AreaId
            };
        }
    }
}
