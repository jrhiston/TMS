using Microsoft.EntityFrameworkCore;
using System.Linq;
using TMS.Data.Entities.Areas;
using TMS.Layer;
using TMS.Layer.Entities;
using TMS.Layer.Repositories;
using TMS.ModelLayer.Areas;

namespace TMS.Database.Commands.Areas
{
    public class SaveAreaCommand : IQueryCommand<Area, AreaKey>
    {
        private readonly IEntityService<Area, AreaEntity> _entityService;

        public SaveAreaCommand(IEntityService<Area, AreaEntity> entityService)
        {
            _entityService = entityService;
        }

        public Maybe<AreaKey> ExecuteCommand(Area data)
        {
            var entity = _entityService.Save<AreaKey>(data, 
                (k, es) => es.FirstOrDefault(e => e.Id == k.Identifier));

            return new Maybe<AreaKey>(new AreaKey(entity.Id));
        }
    }
}
