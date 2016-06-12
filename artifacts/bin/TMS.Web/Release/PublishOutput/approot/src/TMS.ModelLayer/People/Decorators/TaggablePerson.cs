using System;
using System.Collections.Generic;
using TMS.Layer.ModelObjects;
using TMS.ModelLayerInterface.People;
using TMS.ModelLayerInterface.People.Data;
using TMS.ModelLayerInterface.People.Decorators;
using TMS.ModelLayerInterface.Tags;

namespace TMS.ModelLayer.People.Decorators
{
    public class TaggablePerson : DecoratorBase<TaggablePersonData, PersonData>, ITaggablePerson
    {
        private readonly List<ITag> _tags;

        public TaggablePerson(IPerson person, TaggablePersonData data) : base(person)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));
            
            _tags = data.Tags;
        }

        protected override TaggablePersonData GetData() => new TaggablePersonData
        {
            Tags = _tags
        };
    }
}
