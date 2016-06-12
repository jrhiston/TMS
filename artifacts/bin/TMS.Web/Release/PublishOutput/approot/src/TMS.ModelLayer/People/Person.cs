using System;
using TMS.Layer.ModelObjects;
using TMS.ModelLayerInterface.People;
using TMS.ModelLayerInterface.People.Data;

namespace TMS.ModelLayer.People
{
    public class Person : ModelObjectBase<PersonData>, IPerson
    {
        private string _firstName;
        private string _lastName;
        private string _userName;

        public Person(PersonData data)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));

            _firstName = data.FirstName;
            _lastName = data.LastName;
            _userName = data.UserName;
        }

        protected override PersonData GetData() => new PersonData
        {
            FirstName = _firstName,
            LastName = _lastName,
            UserName = _userName
        };
    }
}
