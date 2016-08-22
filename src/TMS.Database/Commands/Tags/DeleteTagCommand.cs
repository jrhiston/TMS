using System;
using System.Linq;
using TMS.Data.Entities.Tags;
using TMS.Layer.Data;
using TMS.Layer.Repositories;
using TMS.ModelLayer.Tags;

namespace TMS.Database.Commands.Tags
{
    public class DeleteTagCommand : INonQueryCommand<TagKey>
    {
        private readonly IDataContextFactory<TagEntity> _contextFactory;

        public DeleteTagCommand(IDataContextFactory<TagEntity> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public void ExecuteCommand(TagKey data)
        {
            using (var context = _contextFactory.Create())
            {
                var existingItem = context
                    .Entities
                    .FirstOrDefault(item => item.Id == data.Identifier);

                if (existingItem == null)
                    throw new InvalidOperationException($"Can not delete an entity if it does not exist. Tag with id: {data.Identifier}");

                context.Entities.Remove(existingItem);

                context.SaveChanges();
            }
        }
    }
}
