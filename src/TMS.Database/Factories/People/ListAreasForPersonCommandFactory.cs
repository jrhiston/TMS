using System.Collections.Generic;
using TMS.Database.Commands.People;
using TMS.Database.Entities.Areas;
using TMS.Layer.Conversion;
using TMS.Layer.Factories;
using TMS.Layer.Repositories;
using TMS.ModelLayerInterface.Areas.Decorators;
using TMS.ModelLayerInterface.People;

namespace TMS.Database.Factories.People
{
    public class ListAreasForPersonCommandFactory : IQueryFactory<IQueryCommand<IPersonKey, IEnumerable<IPersistableArea>>>
    {
        private readonly IConverter<AreaEntity, IPersistableArea> _areaEntityToPersistableAreaConverter;
        private readonly IDatabaseContextFactory<AreaEntity> _contextFactory;

        public ListAreasForPersonCommandFactory(IDatabaseContextFactory<AreaEntity> contextFactory, IConverter<AreaEntity, IPersistableArea> areaEntityToPersistableAreaConverter)
        {
            _contextFactory = contextFactory;
            _areaEntityToPersistableAreaConverter = areaEntityToPersistableAreaConverter;
        }

        public IQueryCommand<IPersonKey, IEnumerable<IPersistableArea>> Create() => new ListAreasForPersonCommand(_contextFactory, _areaEntityToPersistableAreaConverter);
    }
}
