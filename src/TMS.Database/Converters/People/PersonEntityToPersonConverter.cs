using TMS.Database.Entities.People;
using TMS.Layer;
using TMS.Layer.Conversion;
using TMS.Layer.Factories;
using TMS.ModelLayerInterface.People;
using TMS.ModelLayerInterface.People.Data;
using TMS.ModelLayerInterface.People.Decorators;

namespace TMS.Database.Converters.People
{
    public class PersonEntityToPersonConverter : IConverter<PersonEntity, IPersistablePerson>
    {
        private readonly IDecoratorFactory<PersistablePersonData, IPerson, IPersistablePerson> _persistablePersonFactory;
        private readonly IFactory<PersonData, IPerson> _personFactory;
        private readonly IFactory<PersonKeyData, IPersonKey> _personKeyFactory;

        public PersonEntityToPersonConverter(IFactory<PersonData, IPerson> personFactory,
            IFactory<PersonKeyData, IPersonKey> personKeyFactory,
            IDecoratorFactory<PersistablePersonData, IPerson, IPersistablePerson> persistablePersonFactory)
        {
            _personFactory = personFactory;
            _personKeyFactory = personKeyFactory;
            _persistablePersonFactory = persistablePersonFactory;
        }

        public Maybe<IPersistablePerson> Convert(PersonEntity input)
        {
            if (input == null)
                return new Maybe<IPersistablePerson>();

            var key = _personKeyFactory.Create(new PersonKeyData
            {
                Identifier = input.Id
            });

            var person = _personFactory.Create(new PersonData
            {
                FirstName = input.FirstName,
                LastName = input.LastName,
                UserName = input.UserName
            });

            return new Maybe<IPersistablePerson>(_persistablePersonFactory.Create(new PersistablePersonData
            {
                PasswordHash = input.PasswordHash,
                PersonKey = key
            }, person));
        }
    }
}
