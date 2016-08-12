using TMS.Layer.Initialisers;
using TMS.ViewModelLayer.Models.Tags.Pages;

namespace TMS.ApplicationLayer.Tags.Data
{
    public class DeleteTagPageModelInitialiserData : IInitialiserData<DeleteTagPageModel>
    {
        public long PersonId { get; set; }
        public long TagId { get; set; }
    }
}
