using TMS.Data.Entities.People;
using TMS.Layer;
using TMS.Layer.Conversion;
using TMS.ModelLayer.People;

namespace TMS.Database.Converters.People
{
    public class PersonEntityToPersonConverter : IConverter<PersonEntity, Person>
    {
        public Maybe<Person> Convert(PersonEntity input) => new Maybe<Person>(new Person(
            new PersonKey(input.Id),
            new FirstName(input.FirstName),
            new LastName(input.LastName),
            new UserName(input.UserName),
            new PasswordHash(input.PasswordHash)));
    }
}
