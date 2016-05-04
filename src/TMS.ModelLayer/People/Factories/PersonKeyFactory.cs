using TMS.Layer.Factories;
using TMS.ModelLayerInterface.People;
using TMS.ModelLayerInterface.People.Data;

namespace TMS.ModelLayer.People.Factories
{
    public class PersonKeyFactory : IFactory<PersonKeyData, IPersonKey>
    {
        public IPersonKey Create(PersonKeyData data) => new PersonKey
        {
            Identifier = data.Identifier
        };
    }
}
