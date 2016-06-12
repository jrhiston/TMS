using TMS.ModelLayerInterface.People;
using TMS.ModelLayerInterface.People.Decorators;

namespace TMS.RepositoryLayerInterface.CommandObjects.People
{
    public interface IGetPersonCommand
    {
        IPersistablePerson ExecuteCommand(IPersonKey personKey);
    }
}
