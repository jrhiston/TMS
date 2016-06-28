using TMS.Layer.Initialisers;
using TMS.ViewModelLayer.Models.Areas.Pages;

namespace TMS.ApplicationLayer.Areas.Data
{
    public class AreaEditPageModelInitialiserData : IInitialiserData<AreaEditPageModel>
    {
        public long AreaId { get; set; }
    }
}
