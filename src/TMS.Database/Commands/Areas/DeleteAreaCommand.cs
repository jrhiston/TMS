using System;
using System.Linq;
using TMS.Database.Entities.Areas;
using TMS.Layer.Repositories;
using TMS.ModelLayerInterface.Areas;

namespace TMS.Database.Commands.Areas
{
    public class DeleteAreaCommand : INonQueryCommand<IAreaKey>
    {
        private readonly IDatabaseContext<AreaEntity> _areasContext;

        public DeleteAreaCommand(IDatabaseContext<AreaEntity> areasContext)
        {
            _areasContext = areasContext;
        }

        public void ExecuteCommand(IAreaKey data)
        {
            var existingItem = _areasContext.Entities.FirstOrDefault(item => item.Id == data.Identifier);

            if (existingItem == null)
                throw new InvalidOperationException($"Can not delete an entity if it does not exist. Area with id: {data.Identifier}");

            _areasContext.Entities.Remove(existingItem);

            _areasContext.SaveChanges();
        }
    }
}
