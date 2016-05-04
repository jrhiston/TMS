namespace TMS.RepositoryLayerInterface.CommandObjects.People
{
    public interface IPersonCommandFactory
    {
        IDeletePersonCommand CreateDeletePersonCommand();
        IGetPersonCommand CreateGetPersonCommand();
        ISavePersonCommand CreateSavePersonCommand();
        IListPeopleCommand CreateListPeopleCommand();
    }
}