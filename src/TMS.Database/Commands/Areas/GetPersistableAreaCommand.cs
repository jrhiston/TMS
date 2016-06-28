using System.Linq;
using TMS.Database.Entities.Areas;
using TMS.Layer;
using TMS.Layer.Conversion;
using TMS.Layer.Repositories;
using TMS.ModelLayerInterface.Areas;
using TMS.ModelLayerInterface.Areas.Decorators;

namespace TMS.Database.Commands.Areas
{
    public class GetPersistableAreaCommand : IQueryCommand<IAreaKey, IPersistableArea>
    {
        private readonly IConverter<AreaEntity, IPersistableArea> _areaEntityToPersistableAreaConverter;
        private readonly IDatabaseContextFactory<AreaEntity> _contextFactory;

        public GetPersistableAreaCommand(IDatabaseContextFactory<AreaEntity> contextFactory, IConverter<AreaEntity, IPersistableArea> areaEntityToPersistableAreaConverter)
        {
            _contextFactory = contextFactory;
            _areaEntityToPersistableAreaConverter = areaEntityToPersistableAreaConverter;
        }

        public Maybe<IPersistableArea> ExecuteCommand(IAreaKey data)
        {
            using (var context = _contextFactory.Create())
            {
                var area = context.Entities.FirstOrDefault(item => item.Id == data.Identifier);

                if (area != null)
                    return _areaEntityToPersistableAreaConverter.Convert(area);

                return new Maybe<IPersistableArea>();
            }
        }
    }
}
