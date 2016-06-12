using TMS.ModelLayer.TMS.ModelLayerInterface.Areas;

namespace TMS.RepositoryLayerInterface.CommandObjects.Areas
{
    public interface ISaveAreaCommand
    {
        void ExecuteCommand(IArea area);
    }
}