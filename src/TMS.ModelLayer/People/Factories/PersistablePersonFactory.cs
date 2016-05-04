using TMS.Layer.Factories;
using TMS.ModelLayer.People.Decorators;
using TMS.ModelLayerInterface.People;
using TMS.ModelLayerInterface.People.Data;
using TMS.ModelLayerInterface.People.Decorators;

namespace TMS.ModelLayer.People.Factories
{
    public class PersistablePersonFactory : IDecoratorFactory<PersistablePersonData, IPerson, IPersistablePerson>
    {
        public IPersistablePerson Create(PersistablePersonData data, IPerson decoratee) => new PersistablePerson(decoratee, data);
    }
}
