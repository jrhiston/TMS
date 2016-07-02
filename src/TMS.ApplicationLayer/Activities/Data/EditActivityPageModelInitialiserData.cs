using TMS.Layer.Initialisers;
using TMS.ViewModelLayer.Models.Activities.Pages;

namespace TMS.ApplicationLayer.Activities.Data
{
    public class EditActivityPageModelInitialiserData : IInitialiserData<EditActivityPageModel>
    {
        public long ActivityId { get; set; }
        public long AreaId { get; set; }
    }
}
