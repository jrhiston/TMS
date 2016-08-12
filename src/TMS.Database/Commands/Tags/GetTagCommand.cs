﻿using System.Linq;
using TMS.Database.Entities.Tags;
using TMS.Layer;
using TMS.Layer.Conversion;
using TMS.Layer.Repositories;
using TMS.ModelLayer.Tags;

namespace TMS.Database.Commands.Tags
{
    public class GetTagCommand : IQueryCommand<TagKey, Tag>
    {
        private readonly IConverter<TagEntity, Tag> _entityConverter;
        private readonly IDatabaseContextFactory<TagEntity> _contextFactory;

        public GetTagCommand(IDatabaseContextFactory<TagEntity> contextFactory,
            IConverter<TagEntity, Tag> entityConverter)
        {
            _contextFactory = contextFactory;
            _entityConverter = entityConverter;
        }

        public Maybe<Tag> ExecuteCommand(TagKey data)
        {
            using (var context = _contextFactory.Create())
            {
                return _entityConverter.Convert(context.Entities.Single(item => item.Id == data.Identifier));
            }
        }
    }
}
