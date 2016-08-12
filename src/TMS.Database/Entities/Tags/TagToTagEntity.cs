namespace TMS.Database.Entities.Tags
{
    public class TagToTagEntity
    {
        public long ParentTagId { get; set; }
        public TagEntity ParentTag { get; set; }

        public long ChildTagId { get; set; }
        public TagEntity ChildTag { get; set; }
    }
}
