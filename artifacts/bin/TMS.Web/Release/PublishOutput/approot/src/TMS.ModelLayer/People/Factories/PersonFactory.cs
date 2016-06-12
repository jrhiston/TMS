using TMS.Layer.Factories;
using TMS.ModelLayerInterface.People;
using TMS.ModelLayerInterface.People.Data;

namespace TMS.ModelLayer.People.Factories
{
    public class PersonFactory : IFactory<PersonData, IPerson>
    {
        public IPerson Create(PersonData personData) => new Person(personData);
    }
}
