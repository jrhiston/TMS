using System;
using System.Linq;
using TMS.Database.Entities.Activities;
using TMS.Layer.Repositories;
using TMS.ModelLayerInterface.Activities;

namespace TMS.Database.Commands.Activities
{
    public class DeleteActivityCommand : INonQueryCommand<IActivityKey>
    {
        private readonly IDatabaseContextFactory<ActivityEntity> _contextFactory;

        public DeleteActivityCommand(IDatabaseContextFactory<ActivityEntity> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public void ExecuteCommand(IActivityKey data)
        {
            using (var context = _contextFactory.Create())
            {
                var existingItem = context.Entities.FirstOrDefault(item => item.Id == data.Identifier);

                if (existingItem == null)
                    throw new InvalidOperationException($"Can not delete an entity if it does not exist. Activity with id: {data.Identifier}");

                context.Entities.Remove(existingItem);

                context.SaveChanges();
            }
        }
    }
}
