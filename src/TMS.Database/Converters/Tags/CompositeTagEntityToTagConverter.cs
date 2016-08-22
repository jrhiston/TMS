using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMS.Data.Entities.Tags;
using TMS.Layer;
using TMS.Layer.Conversion;
using TMS.ModelLayer.Tags;

namespace TMS.Database.Converters.Tags
{
    public class CompositeTagEntityToTagConverter : IEnumerable<IConverter<TagEntity, ITagElement>>, IConverter<TagEntity, Tag>
    {
        private readonly IEnumerable<IConverter<TagEntity, ITagElement>> _converters;

        public CompositeTagEntityToTagConverter(params IConverter<TagEntity, ITagElement>[] converters)
        {
            _converters = converters;
        }

        public Maybe<Tag> Convert(TagEntity input)
        {
            return _converters
                .Aggregate(new Tag(), (t, c) => new Tag(t.Append(c.Convert(input).Single()).ToArray()))
                .ToMaybe();
        }

        public IEnumerator<IConverter<TagEntity, ITagElement>> GetEnumerator()
        {
            return _converters.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
