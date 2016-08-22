using System.Linq;
using Microsoft.EntityFrameworkCore;
using TMS.Data.Entities.Areas;
using TMS.Layer;
using TMS.Layer.Conversion;
using TMS.Layer.Repositories;
using TMS.ModelLayer.Areas;
using TMS.Layer.Data;

namespace TMS.Database.Commands.Areas
{
    public class GetAreaCommand : IQueryCommand<AreaKey, Area>
    {
        private readonly IConverter<AreaEntity, Area> _areaEntityToAreaConverter;
        private readonly IDataContextFactory<AreaEntity> _contextFactory;

        public GetAreaCommand(IDataContextFactory<AreaEntity> contextFactory, IConverter<AreaEntity, Area> areaEntityToAreaConveter)
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
                        .Single(item => item.Id == data.Identifier));
            }
        }
    }
}
