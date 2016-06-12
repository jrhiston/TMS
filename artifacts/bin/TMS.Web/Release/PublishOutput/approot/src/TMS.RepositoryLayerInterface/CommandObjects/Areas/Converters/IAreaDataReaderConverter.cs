using System.Data.Common;
using TMS.Layer.Conversion;
using TMS.ModelLayerInterface.Areas.Decorators;

namespace TMS.RepositoryLayerInterface.CommandObjects.Areas.Converters
{
    public interface IAreaDataReaderConverter : IConverter<DbDataReader, IPersistableArea>
    {
    }
}
