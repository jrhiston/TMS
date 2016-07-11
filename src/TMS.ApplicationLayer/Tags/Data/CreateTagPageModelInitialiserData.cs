using TMS.Layer.Initialisers;
using TMS.ViewModelLayer.Models.Tags;
using TMS.ViewModelLayer.Models.Tags.Pages;

namespace TMS.ApplicationLayer.Tags.Data
{
    public class CreateTagForActivityPageModelInitialiserData : IInitialiserData<CreateTagForActivityPageModel>
    {
        public long ActivityId { get; set; }
    }
}
