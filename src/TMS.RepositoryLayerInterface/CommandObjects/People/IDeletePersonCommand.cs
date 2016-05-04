using TMS.LayerInterface.People;
using TMS.ModelLayerInterface.People;

namespace TMS.RepositoryLayerInterface.CommandObjects.People
{
    public interface IDeletePersonCommand
    {
        void ExecuteCommand(IPersonKey key);
    }
}
