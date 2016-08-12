using TMS.Layer.Initialisers;
using TMS.ModelLayer.People;
using TMS.ViewModelLayer.Models.Tags.Pages;

namespace TMS.ApplicationLayer.Tags.Data
{
    public class TagsPageModelInitialiserData : IInitialiserData<TagsPageModel>
    {
        public PersonKey CurrentUserKey { get; set; }
    }
}
