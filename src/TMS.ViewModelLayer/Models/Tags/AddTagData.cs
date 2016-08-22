using TMS.ViewModelLayer.Models.Tags.AddTagContextTypes;

namespace TMS.ViewModelLayer.Models.Tags
{
    public class AddTagData
    {
        public long ObjectId { get; set; }

        public AddTagContextTypeBase Context { get; set; }
    }
}
