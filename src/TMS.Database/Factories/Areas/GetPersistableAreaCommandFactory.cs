using TMS.Database.Commands.Areas;
using TMS.Database.Entities.Areas;
using TMS.Layer.Conversion;
using TMS.Layer.Factories;
using TMS.Layer.Repositories;
using TMS.ModelLayerInterface.Areas;
using TMS.ModelLayerInterface.Areas.Decorators;

namespace TMS.Database.Factories.Areas
{
    public class GetPersistableAreaCommandFactory : IQueryFactory<IQueryCommand<IAreaKey, IPersistableArea>>
    {
        private readonly IConverter<AreaEntity, IPersistableArea> _areaEntityToPersistableAreaConverter;
        private readonly IDatabaseContextFactory<AreaEntity> _contextFactory;

        public GetPersistableAreaCommandFactory(IDatabaseContextFactory<AreaEntity> contextFactory, IConverter<AreaEntity, IPersistableArea> areaEntityToPersistableAreaConverter)
        {
            _contextFactory = contextFactory;
            _areaEntityToPersistableAreaConverter = areaEntityToPersistableAreaConverter;
        }

        public IQueryCommand<IAreaKey, IPersistableArea> Create()
        {
            return new GetPersistableAreaCommand(_contextFactory, _areaEntityToPersistableAreaConverter);
        }
    }
}
