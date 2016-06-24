using TMS.ApplicationLayer.Activities.Data;
using TMS.Layer.Initialisers;
using TMS.ViewModelLayer.Models.Activities.Pages;

namespace TMS.ApplicationLayer.Activities
{
    public class CreateActivityPageModelInitialiser : IInitialiser<CreateActivityPageModelInitialiserData, CreateActivityPageModel>
    {
        public CreateActivityPageModel Initialise(CreateActivityPageModelInitialiserData data)
        {
            return new CreateActivityPageModel
            {
                AreaId = data.AreaId
            };
        }
    }
}
