using TMS.Layer.Initialisers;
using TMS.ViewModelLayer.Models.Tags;
using TMS.ViewModelLayer.Models.Tags.Pages;

namespace TMS.ApplicationLayer.Tags.Data
{
    public class EditTagPageModelInitialiserData : IInitialiserData<EditTagPageModel>
    {
        public long TagId { get; set; }
    }
}
