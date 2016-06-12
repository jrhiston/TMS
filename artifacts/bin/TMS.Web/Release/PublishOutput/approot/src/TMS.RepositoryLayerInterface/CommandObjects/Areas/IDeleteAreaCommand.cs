using TMS.ModelLayerInterface.Areas;

namespace TMS.RepositoryLayerInterface.CommandObjects.Areas
{
    public interface IDeleteAreaCommand
    {
        void ExecuteCommand(IAreaKey area);
    }
}