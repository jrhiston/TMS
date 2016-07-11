using System.Collections.Generic;
using TMS.ApplicationLayer.Activities.Data;
using TMS.ApplicationLayer.Tags.Data;
using TMS.Layer.Initialisers;
using TMS.ViewModelLayer.Models.Tags;
using TMS.ViewModelLayer.Models.Tags.Pages;

namespace TMS.ApplicationLayer.Tags
{
    public class CreateTagForActivityPageModelInitialiser : IInitialiser<CreateTagForActivityPageModelInitialiserData, CreateTagForActivityPageModel>
    {
        public CreateTagForActivityPageModel Initialise(CreateTagForActivityPageModelInitialiserData value)
        {
            return new CreateTagForActivityPageModel
            {
                ActivityId = value.ActivityId
            };
        }
    }
}