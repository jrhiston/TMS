using System;
using System.Linq;
using TMS.ApplicationLayer.Activities.Data;
using TMS.Layer.Factories;
using TMS.Layer.Initialisers;
using TMS.Layer.Readers;
using TMS.ModelLayerInterface.Activities;
using TMS.ModelLayerInterface.Activities.Data;
using TMS.ViewModelLayer.Models.Activities;
using TMS.ViewModelLayer.Models.Activities.Pages;

namespace TMS.ApplicationLayer.Activities
{
    public class DeleteActivityPageModelInitialiser : IInitialiser<DeleteActivityPageModelInitialiserData, DeleteActivityPageModel>
    {
        private readonly IFactory<ActivityKeyData, IActivityKey> _areaKeyFactory;
        private readonly IReader<IActivityKey, IActivity> _areaReader;

        public DeleteActivityPageModelInitialiser(IReader<IActivityKey, IActivity> areaReader,
            IFactory<ActivityKeyData, IActivityKey> areaKeyFactory)
        {
            _areaReader = areaReader;
            _areaKeyFactory = areaKeyFactory;
        }

        public DeleteActivityPageModel Initialise(DeleteActivityPageModelInitialiserData data)
        {
            var activityKey = _areaKeyFactory.Create(new ActivityKeyData
            {
                Identifier = data.ActivityId
            });

            var areaViewModel = _areaReader
                .Read(activityKey)
                .Select(activity => new ActivityViewModel(activity))
                .FirstOrDefault();

            if (areaViewModel == null)
                throw new InvalidOperationException($"Failed to find activity matching the given id {data.ActivityId}");

            return new DeleteActivityPageModel
            {
                Id = areaViewModel.Id,
                Name = areaViewModel.Title,
                AreaId = data.AreaId
            };
        }
    }
}
