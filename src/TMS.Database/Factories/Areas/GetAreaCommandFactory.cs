using TMS.Database.Commands.Areas;
using TMS.Database.Entities.Areas;
using TMS.Layer.Conversion;
using TMS.Layer.Factories;
using TMS.Layer.Repositories;
using TMS.ModelLayer.TMS.ModelLayerInterface.Areas;
using TMS.ModelLayerInterface.Areas;

namespace TMS.Database.Factories.Areas
{
    public class GetAreaCommandFactory : IQueryFactory<IQueryCommand<IAreaKey, IArea>>
    {
        private readonly IConverter<AreaEntity, IArea> _areaEntityToAreaConverter;
        private readonly IDatabaseContextFactory<AreaEntity> _contextFactory;

        public GetAreaCommandFactory(IDatabaseContextFactory<AreaEntity> contextFactory, IConverter<AreaEntity, IArea> areaEntityToAreaConverter)
        {
            _contextFactory = contextFactory;
            _areaEntityToAreaConverter = areaEntityToAreaConverter;
        }

        public IQueryCommand<IAreaKey, IArea> Create() => new GetAreaCommand(_contextFactory, _areaEntityToAreaConverter);
    }
}
