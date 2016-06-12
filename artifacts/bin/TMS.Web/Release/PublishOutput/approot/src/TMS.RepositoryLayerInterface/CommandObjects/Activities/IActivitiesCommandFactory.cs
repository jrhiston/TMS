using TMS.RepositoryLayerInterface.CommandObjects.Activities.Tags;

namespace TMS.RepositoryLayerInterface.CommandObjects.Activities
{
    public interface IActivitiesCommandFactory
    {
        IDeleteActivityCommand CreateDeleteActivityCommand();
        IGetActivityCommand CreateGetActivityCommand();
        ISaveActivityCommand CreateSaveActivityCommand();
        IListActivitiesCommand CreateListActivitiesCommand();
        IAddTagToActivityCommand CreateAddTagToActivityCommand();
        IDeleteTagFromActivityCommand CreateDeleteTagFromActivityCommand();
        ISaveActivityTagsCommand CreateSaveActivityTagsCommand();
        IActivityTagLinkExistsCommand CreateActivityTagLinkExistsCommand();
    }
}