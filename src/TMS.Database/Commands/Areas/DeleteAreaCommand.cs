using System;
using System.Linq;
using TMS.Data.Entities.Areas;
using TMS.Layer.Data;
using TMS.Layer.Repositories;
using TMS.ModelLayer.Areas;

namespace TMS.Database.Commands.Areas
{
    public class DeleteAreaCommand : INonQueryCommand<AreaKey>
    {
        private readonly IDataContextFactory<AreaEntity> _contextFactory;

        public DeleteAreaCommand(IDataContextFactory<AreaEntity> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public void ExecuteCommand(AreaKey data)
        {
            using (var context = _contextFactory.Create())
            {
                var existingItem = context.Entities.FirstOrDefault(item => item.Id == data.Identifier);

                if (existingItem == null)
                    throw new InvalidOperationException($"Can not delete an entity if it does not exist. Area with id: {data.Identifier}");

                context.Entities.Remove(existingItem);

                context.SaveChanges();
            }
        }
    }
}
