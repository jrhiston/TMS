using System;

namespace TMS.ViewModelLayer.Models.Tags.Pages
{
    public class EditTagPageModel
    {
        public bool CanSetOnActivity { get; set; }
        public DateTime Created { get; set; }
        public string Description { get; set; }
        public long TagId { get; set; }
        public string TagName { get; set; }
    }
}
