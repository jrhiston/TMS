using System;
using System.Linq;
using TMS.Data.Entities.Activities;
using TMS.Layer.Data;
using TMS.Layer.Repositories;
using TMS.ModelLayer.Activities;

namespace TMS.Database.Commands.Activities
{
    public class DeleteActivityCommand : INonQueryCommand<ActivityKey>
    {
        private readonly IDataContextFactory<ActivityEntity> _contextFactory;

        public DeleteActivityCommand(IDataContextFactory<ActivityEntity> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public void ExecuteCommand(ActivityKey data)
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
