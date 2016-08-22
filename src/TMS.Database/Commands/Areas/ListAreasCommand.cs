using System.Collections.Generic;
using System.Linq;
using TMS.Data.Entities.Areas;
using TMS.Layer;
using TMS.Layer.Conversion;
using TMS.Layer.Data;
using TMS.Layer.Repositories;
using TMS.ModelLayer.Areas;

namespace TMS.Database.Commands.Areas
{
    public class ListAreasCommand : IQueryCommand<AreaFilterData, IEnumerable<Area>>
    {
        private readonly IDataContextFactory<AreaEntity> _contextFactory;
        private readonly IConverter<AreaEntity, Area> _converter;

        public ListAreasCommand(IDataContextFactory<AreaEntity> contextFactory,
            IConverter<AreaEntity, Area> converter)
        {
            _contextFactory = contextFactory;
            _converter = converter;
        }

        public Maybe<IEnumerable<Area>> ExecuteCommand(AreaFilterData data)
        {
            using (var context = _contextFactory.Create())
            {
                if (data == null)
                    return new Maybe<IEnumerable<Area>>();

                var areas = context.Entities.Where(item => item.Id == data.AreaKey.Identifier);

                return new Maybe<IEnumerable<Area>>(areas
                    .Select(area => _converter.Convert(area))
                    .SelectMany(item => item)
                    .ToList());
            }
        }
    }
}
