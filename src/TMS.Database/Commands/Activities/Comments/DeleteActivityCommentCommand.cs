using System;
using System.Linq;
using TMS.Data.Entities.Activities.Comments;
using TMS.Layer.Data;
using TMS.Layer.Repositories;
using TMS.ModelLayer.Activities.Comments;

namespace TMS.Database.Commands.Activities.Comments
{
    public class DeleteActivityCommentCommand : INonQueryCommand<ActivityCommentKey>
    {
        private readonly IDataContextFactory<ActivityCommentEntity> _contextFactory;

        public DeleteActivityCommentCommand(IDataContextFactory<ActivityCommentEntity> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public void ExecuteCommand(ActivityCommentKey data)
        {
            using (var context = _contextFactory.Create())
            {
                var existingItem = context.Entities.FirstOrDefault(item => item.Id == data.Identifier);

                if (existingItem == null)
                    throw new InvalidOperationException($"Can not delete an entity if it does not exist. Activity Comment with id: {data.Identifier}");

                context.Entities.Remove(existingItem);

                context.SaveChanges();
            }
        }
    }
}
