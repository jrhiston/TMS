using System;
using TMS.Layer.ModelObjects;
using TMS.ModelLayerInterface.People;
using TMS.ModelLayerInterface.People.Data;
using TMS.ModelLayerInterface.People.Decorators;

namespace TMS.ModelLayer.People.Decorators
{
    public class PersistablePerson : DecoratorBase<PersistablePersonData, PersonData>, IPersistablePerson
    {
        private readonly IPersonKey _personKey;
        private readonly string _passwordHash;

        public PersistablePerson(IPerson person,
            PersistablePersonData data) : base(person)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));

            _personKey = data.PersonKey;
            _passwordHash = data.PasswordHash;
        }

        protected override PersistablePersonData GetData() => new PersistablePersonData
        {
            PasswordHash = _passwordHash,
            PersonKey = _personKey
        };
    }
}
