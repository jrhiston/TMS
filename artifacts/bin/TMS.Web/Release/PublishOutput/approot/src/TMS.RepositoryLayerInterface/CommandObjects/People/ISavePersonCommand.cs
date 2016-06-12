using TMS.LayerInterface.People;
using TMS.ModelLayerInterface.People;
using TMS.ModelLayerInterface.People.Decorators;

namespace TMS.RepositoryLayerInterface.CommandObjects.People
{
    public interface ISavePersonCommand
    {
        IPersonKey ExecuteCommand(IPersistablePerson personData);
    }
}
