using System.Linq;
using TMS.Database.Entities.Areas;
using TMS.Layer;
using TMS.Layer.Conversion;
using TMS.Layer.Repositories;
using TMS.ModelLayerInterface.Areas;
using TMS.ModelLayerInterface.Areas.Decorators;

namespace TMS.Database.Commands.Areas
{
    public class GetAreaCommand : IQueryCommand<IAreaKey, IPersistableArea>
    {
        private readonly IConverter<AreaEntity, IPersistableArea> _areaEntityToPersistableAreaConverter;
        private readonly IDatabaseContext<AreaEntity> _areasContext;

        public GetAreaCommand(IDatabaseContext<AreaEntity> areasContext, IConverter<AreaEntity, IPersistableArea> areaEntityToPersistableAreaConverter)
        {
            _areasContext = areasContext;
            _areaEntityToPersistableAreaConverter = areaEntityToPersistableAreaConverter;
        }

        public Maybe<IPersistableArea> ExecuteCommand(IAreaKey data)
        {
            var area = _areasContext.Entities.FirstOrDefault(item => item.Id == data.Identifier);

            if (area != null)
                return _areaEntityToPersistableAreaConverter.Convert(area);

            return new Maybe<IPersistableArea>();
        }
    }
}
