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
    public class EditActivityPageModelInitialiser : IInitialiser<EditActivityPageModelInitialiserData, EditActivityPageModel>
    {
        private readonly IFactory<ActivityKeyData, IActivityKey> _areaKeyFactory;
        private readonly IReader<IActivityKey, IActivity> _areaReader;

        public EditActivityPageModelInitialiser(IReader<IActivityKey, IActivity> areaReader,
            IFactory<ActivityKeyData, IActivityKey> areaKeyFactory)
        {
            _areaReader = areaReader;
            _areaKeyFactory = areaKeyFactory;
        }

        public EditActivityPageModel Initialise(EditActivityPageModelInitialiserData data)
        {
            var areaKey = _areaKeyFactory.Create(new ActivityKeyData
            {
                Identifier = data.ActivityId
            });

            var area = _areaReader.Read(areaKey);

            _composer.Read(areaKey)
                .Include<IPersistableTag>()
                .GetResult();

            if (!area.Any())
                throw new InvalidOperationException($"Failed to find activity for given identifier {data.ActivityId}");

            var activityViewModel = new ActivityViewModel(area.FirstOrDefault());

            return new EditActivityPageModel
            {
                Id = activityViewModel.Id,
                AreaId = data.AreaId,
                Name = activityViewModel.Title,
                Description = activityViewModel.Description,
                Tags = activityViewModel.Tags
            };
        }
    }
}
