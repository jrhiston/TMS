using System.Data.Common;
using TMS.Layer.Conversion;
using TMS.ModelLayerInterface.Activities.Decorators;

namespace TMS.RepositoryLayerInterface.CommandObjects.Activities.Converters
{
    public interface IPersistableActivityDataReaderConverter : IConverter<DbDataReader, IPersistableActivity>
    {
    }
}
