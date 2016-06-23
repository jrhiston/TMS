using System.Linq;
using TMS.Database.Entities.Areas;
using TMS.Layer;
using TMS.Layer.Conversion;
using TMS.Layer.Repositories;
using TMS.ModelLayer.TMS.ModelLayerInterface.Areas;
using TMS.ModelLayerInterface.Areas;

namespace TMS.Database.Commands.Areas
{
    public class GetAreaCommand : IQueryCommand<IAreaKey, IArea>
    {
        private readonly IConverter<AreaEntity, IArea> _areaEntityToAreaConveter;
        private readonly IDatabaseContext<AreaEntity> _areasContext;

        public GetAreaCommand(IDatabaseContext<AreaEntity> areasContext, IConverter<AreaEntity, IArea> areaEntityToAreaConveter)
        {
            _areasContext = areasContext;
            _areaEntityToAreaConveter = areaEntityToAreaConveter;
        }

        public Maybe<IArea> ExecuteCommand(IAreaKey data) => _areaEntityToAreaConveter
            .Convert(_areasContext
            .Entities
            .Single(item => item.Id == data.Identifier));
    }
}
