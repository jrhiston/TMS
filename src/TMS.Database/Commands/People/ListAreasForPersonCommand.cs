using System.Collections.Generic;
using System.Linq;
using TMS.Database.Entities.Areas;
using TMS.Layer;
using TMS.Layer.Conversion;
using TMS.Layer.Repositories;
using TMS.ModelLayerInterface.Areas.Decorators;
using TMS.ModelLayerInterface.People;

namespace TMS.Database.Commands.People
{
    public class ListAreasForPersonCommand : IQueryCommand<IPersonKey, IEnumerable<IPersistableArea>>
    {
        private readonly IConverter<AreaEntity, IPersistableArea> _areaEntityToPersistableAreaConverter;
        private readonly IDatabaseContextFactory<AreaEntity> _contextFactory;

        public ListAreasForPersonCommand(IDatabaseContextFactory<AreaEntity> contextFactory, IConverter<AreaEntity, IPersistableArea> areaEntityToPersistableAreaConverter)
        {
            _contextFactory = contextFactory;
            _areaEntityToPersistableAreaConverter = areaEntityToPersistableAreaConverter;
        }

        public Maybe<IEnumerable<IPersistableArea>> ExecuteCommand(IPersonKey data)
        {
            if (data == null)
                return new Maybe<IEnumerable<IPersistableArea>>();

            using (var context = _contextFactory.Create())
            {
                var areas = from area in context.Entities
                            where area.AreaPersons.Any(a => a.PersonId == data.Identifier)
                            select area;

                return new Maybe<IEnumerable<IPersistableArea>>(areas
                    .Select(area => _areaEntityToPersistableAreaConverter.Convert(area))
                    .SelectMany(item => item)
                    .ToList());
            }
        }
    }
}
