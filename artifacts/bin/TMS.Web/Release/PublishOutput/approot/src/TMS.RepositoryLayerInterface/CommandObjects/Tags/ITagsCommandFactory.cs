namespace TMS.RepositoryLayerInterface.CommandObjects.Tags
{
    public interface ITagsCommandFactory
    {
        IDeleteTagCommand CreateDeleteTagCommand();
        IGetTagCommand CreateGetTagCommand();
        ISaveTagCommand CreateSaveTagCommand();
        IListTagsCommand CreateListTagsCommand();
        IAddParentTagToTagCommand CreateAddParentTagToTagCommand();
        IDeleteParentTagFromTagCommand CreateDeleteParentTagFromTagCommand();
        ISaveTagsCommand CreateSaveTagsOnActivityCommand();
        ISaveTagsOnTagCommand CreateSaveTagsOnTagCommand();
        ITagLinkExistsCommand CreateTagLinkExistsCommand();
    }
}