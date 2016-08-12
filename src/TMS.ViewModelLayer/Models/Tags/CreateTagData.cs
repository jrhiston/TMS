using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMS.ModelLayer.Tags;

namespace TMS.ViewModelLayer.Models.Tags
{
    public class CreateTagData
    {
        public string Controller { get; set; }
        public string Action { get; set; }
        public long ObjectId { get; set; }
        public bool CanSetOnActivity { get; set; }
        public IEnumerable<TagKey> ExistingTags { get; set; }
    }
}
