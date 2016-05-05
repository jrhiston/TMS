using TMS.Database.Commands.Areas;
using TMS.Database.Contexts;
using TMS.Database.Entities.Areas;
using TMS.Layer.Conversion;
using TMS.Layer.Factories;
using TMS.Layer.Repositories;
using TMS.ModelLayerInterface.Areas;
using TMS.ModelLayerInterface.Areas.Decorators;

namespace TMS.Database.Factories.Areas
{
    public class GetAreaCommandFactory : IQueryFactory<IQueryCommand<IAreaKey, IPersistableArea>>
    {
        private readonly IConverter<AreaEntity, IPersistableArea> _areaEntityToPersistableAreaConverter;
        private readonly MainContext _areasContext;

        public GetAreaCommandFactory(MainContext areasContext, IConverter<AreaEntity, IPersistableArea> areaEntityToPersistableAreaConverter)
        {
            _areasContext = areasContext;
            _areaEntityToPersistableAreaConverter = areaEntityToPersistableAreaConverter;
        }

        public IQueryCommand<IAreaKey, IPersistableArea> Create()
        {
            return new GetAreaCommand(_areasContext, _areaEntityToPersistableAreaConverter);
        }
    }
}
