using TMS.Layer.Initialisers;
using TMS.ViewModelLayer.Models.Activities.Pages;

namespace TMS.ApplicationLayer.Activities.Data
{
    public class DeleteActivityPageModelInitialiserData : IInitialiserData<DeleteActivityPageModel>
    {
        public long PersonId { get; set; }
        public long ActivityId { get; set; }
    }
}
