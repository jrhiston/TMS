using System;

namespace TMS.ViewModelLayer.Models.Tags.Pages
{
    public class TagPageModelBase
    {
        public long AuthorId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long TagId { get; set; }
        public DateTime Created { get; set; }
        public bool CanSetOnActivity { get; set; }
    }
}
