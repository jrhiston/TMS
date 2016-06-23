using TMS.Layer.Initialisers;
using TMS.ViewModelLayer.Models.Areas;

namespace TMS.ApplicationLayer.Areas.Data
{
    public class DeleteAreaPageModelInitialiserData : IInitialiserData<DeleteAreaPageModel>
    {
        public long PersonId { get; set; }
        public long AreaId { get; set; }
    }
}
