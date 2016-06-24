using TMS.Layer.Initialisers;
using TMS.ViewModelLayer.Models.Activities.Pages;

namespace TMS.ApplicationLayer.Activities.Data
{
    public class CreateActivityPageModelInitialiserData : IInitialiserData<CreateActivityPageModel>
    {
        public long AreaId { get; set; }
    }
}
