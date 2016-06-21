using TMS.Layer.Visitors;
using TMS.ModelLayerInterface.People.Data;
using TMS.ModelLayerInterface.People.Decorators;

namespace TMS.ViewModelLayer.Models.People
{
    public class PersonPasswordHashViewModel : IVisitor<PersonData>, IVisitor<PersistablePersonData>
    {
        public string PasswordHash { get; private set; }

        public PersonPasswordHashViewModel(IPersistablePerson persistablePerson)
        {
            persistablePerson.Accept(() => this);
        }

        public void Visit(PersistablePersonData data)
        {
            PasswordHash = data.PasswordHash;
        }

        public void Visit(PersonData data)
        {
            
        }
    }
}
