namespace TMS.ViewModelLayer.Models.Tags
{
    public class TagListFilterData
    {
        public long? ActivityId { get; set; }
        public long? ChildTagId { get; set; }
        public long? ParentTagId { get; set; }
        public bool? Reusable { get; set; }
    }
}
