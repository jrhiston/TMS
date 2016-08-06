using System.Collections.Generic;
using System.Linq;
using TMS.Database.Entities.Areas;
using TMS.Layer;
using TMS.Layer.Conversion;
using TMS.Layer.Repositories;
using TMS.ModelLayer.Areas;
using TMS.ModelLayer.People;

namespace TMS.Database.Commands.People
{
    public class ListAreasForPersonCommand : IQueryCommand<PersonKey, IEnumerable<Area>>
    {
        private readonly IConverter<AreaEntity, Area> _converter;
        private readonly IDatabaseContextFactory<AreaEntity> _contextFactory;

        public ListAreasForPersonCommand(IDatabaseContextFactory<AreaEntity> contextFactory, IConverter<AreaEntity, Area> converter)
        {
            _contextFactory = contextFactory;
            _converter = converter;
        }

        public Maybe<IEnumerable<Area>> ExecuteCommand(PersonKey data)
        {
            if (data == null)
                return new Maybe<IEnumerable<Area>>();

            using (var context = _contextFactory.Create())
            {
                var areas = from area in context.Entities
                            where area.AreaPersons.Any(a => a.PersonId == data.Identifier)
                            select area;

                return new Maybe<IEnumerable<Area>>(areas
                    .Select(area => _converter.Convert(area))
                    .SelectMany(item => item)
                    .ToList());
            }
        }
    }
}
