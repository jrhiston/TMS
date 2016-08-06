using System.Linq;
using TMS.Database.Entities.People;
using TMS.Layer;
using TMS.Layer.Conversion;
using TMS.Layer.Repositories;
using TMS.ModelLayer.People;

namespace TMS.Database.Commands.People
{
    public class GetPersonCommand : IQueryCommand<PersonKey, Person>
    {
        private readonly IDatabaseContextFactory<PersonEntity> _contextFactory;
        private readonly IConverter<PersonEntity, Person> _personConverter;

        public GetPersonCommand(IDatabaseContextFactory<PersonEntity> contextFactory, IConverter<PersonEntity, Person> personConverter)
        {
            _contextFactory = contextFactory;
            _personConverter = personConverter;
        }

        public Maybe<Person> ExecuteCommand(PersonKey data)
        {
            using (var context = _contextFactory.Create())
            {
                return _personConverter
                    .Convert(context
                        .Entities
                        .Single(item => item.Id == data.Identifier));
            }
        }
    }
}
