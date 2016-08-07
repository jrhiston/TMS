using System;
using TMS.Layer;
using TMS.Layer.Repositories;
using TMS.ModelLayer.Tags;

namespace TMS.Database.Commands.Tags
{
    public class SaveTagCommand : IQueryCommand<Tag, TagKey>
    {
        public Maybe<TagKey> ExecuteCommand(Tag data)
        {
            throw new NotImplementedException();
        }
    }
}
