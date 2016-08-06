using System.Linq;
using Microsoft.EntityFrameworkCore;
using TMS.Database.Entities.Areas;
using TMS.Layer;
using TMS.Layer.Conversion;
using TMS.Layer.Repositories;
using TMS.ModelLayer.Areas;

namespace TMS.Database.Commands.Areas
{
    public class GetAreaCommand : IQueryCommand<AreaKey, Area>
    {
        private readonly IConverter<AreaEntity, Area> _areaEntityToAreaConverter;
        private readonly IDatabaseContextFactory<AreaEntity> _contextFactory;

        public GetAreaCommand(IDatabaseContextFactory<AreaEntity> contextFactory, IConverter<AreaEntity, Area> areaEntityToAreaConveter)
        {
            _contextFactory = contextFactory;
            _areaEntityToAreaConverter = areaEntityToAreaConveter;
        }

        public Maybe<Area> ExecuteCommand(AreaKey data)
        {
            using (var context = _contextFactory.Create())
            {
                return _areaEntityToAreaConverter
                    .Convert(context
                        .Entities
                        .Include(area => area.Activities)
                        .Include(area => area.AreaPersons)
                        .Single(item => item.Id == data.Identifier));
            }
        }
    }
}
