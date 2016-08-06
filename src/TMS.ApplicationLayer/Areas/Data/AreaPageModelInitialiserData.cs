using TMS.Layer.Initialisers;
using TMS.ModelLayer.People;
using TMS.ViewModelLayer.Models.Areas.Pages;

namespace TMS.ApplicationLayer.Areas.Data
{
    public class AreaPageModelInitialiserData : IInitialiserData<AreaPageModel>
    {
        public PersonKey CurrentUserKey { get; set; }
    }
}
