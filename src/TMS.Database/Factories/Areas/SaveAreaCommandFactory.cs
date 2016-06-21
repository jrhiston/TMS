using TMS.Database.Commands.Areas;
using TMS.Database.Entities.Areas;
using TMS.Layer.Conversion;
using TMS.Layer.Factories;
using TMS.Layer.Repositories;
using TMS.ModelLayerInterface.Areas;
using TMS.ModelLayerInterface.Areas.Data;
using TMS.ModelLayerInterface.Areas.Decorators;

namespace TMS.Database.Factories.Areas
{
    public class SaveAreaCommandFactory : IQueryFactory<IQueryCommand<IPersistableArea, IAreaKey>>
    {
        private readonly IConverter<IPersistableArea, AreaEntity> _persistableAreaToEntityConverter;
        private readonly IFactory<AreaKeyData, IAreaKey> _areaKeyFactory;
        private readonly IDatabaseContext<AreaEntity> _areasContext;

        public SaveAreaCommandFactory(IDatabaseContext<AreaEntity> areasContext,
            IConverter<IPersistableArea, AreaEntity> persistableAreaToEntityConverter,
            IFactory<AreaKeyData, IAreaKey> areaKeyFactory)
        {
            _areasContext = areasContext;
            _persistableAreaToEntityConverter = persistableAreaToEntityConverter;
            _areaKeyFactory = areaKeyFactory;
        }

        public IQueryCommand<IPersistableArea, IAreaKey> Create() => new SavePersistableAreaCommand(_areasContext, _persistableAreaToEntityConverter, _areaKeyFactory);
    }
}
