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
        private readonly IDatabaseContext<AreaEntity> _areasContext;

        public GetAreaCommandFactory(IDatabaseContext<AreaEntity> areasContext, IConverter<AreaEntity, IArea> areaEntityToAreaConverter)
        {
            _areasContext = areasContext;
            _areaEntityToAreaConverter = areaEntityToAreaConverter;
        }

        public IQueryCommand<IAreaKey, IArea> Create() => new GetAreaCommand(_areasContext, _areaEntityToAreaConverter);
    }
}
