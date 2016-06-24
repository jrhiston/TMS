using System;
using System.Linq;
using TMS.Database.Entities.Activities;
using TMS.Layer.Repositories;
using TMS.ModelLayerInterface.Activities;

namespace TMS.Database.Commands.Activities
{
    public class DeleteActivityCommand : INonQueryCommand<IActivityKey>
    {
        private readonly IDatabaseContext<ActivityEntity> _activitiesContext;

        public DeleteActivityCommand(IDatabaseContext<ActivityEntity> activitiesContext)
        {
            _activitiesContext = activitiesContext;
        }

        public void ExecuteCommand(IActivityKey data)
        {
            var existingItem = _activitiesContext.Entities.FirstOrDefault(item => item.Id == data.Identifier);

            if (existingItem == null)
                throw new InvalidOperationException($"Can not delete an entity if it does not exist. Activity with id: {data.Identifier}");

            _activitiesContext.Entities.Remove(existingItem);

            _activitiesContext.SaveChanges();
        }
    }
}
