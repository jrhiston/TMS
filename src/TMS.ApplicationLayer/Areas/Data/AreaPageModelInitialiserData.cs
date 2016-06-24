using TMS.Layer.Initialisers;
using TMS.ModelLayerInterface.People;
using TMS.ViewModelLayer.Models.Areas;
using TMS.ViewModelLayer.Models.Areas.Pages;

namespace TMS.ApplicationLayer.Areas.Data
{
    public class AreaPageModelInitialiserData : IInitialiserData<AreaPageModel>
    {
        public IPersonKey CurrentUserKey { get; set; }
    }
}
