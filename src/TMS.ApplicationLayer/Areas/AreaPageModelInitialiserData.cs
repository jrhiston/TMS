using TMS.Layer.Initialisers;
using TMS.ModelLayerInterface.People;
using TMS.ViewModelLayer.Models.Areas;

namespace TMS.ApplicationLayer.Areas
{
    public class AreaPageModelInitialiserData : IInitialiserData<AreaPageModel>
    {
        public IPersonKey CurrentUserKey { get; set; }
    }
}
