using TMS.Layer.Visitors;
using TMS.ModelLayerInterface.People;
using TMS.ModelLayerInterface.People.Data;

namespace TMS.ViewModelLayer.Models.People
{
    public class PersonListItemViewModel : IVisitor<PersonData>, IVisitor<PersistablePersonData>
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }

        public PersonListItemViewModel(IPerson activity)
        {
            activity.Accept(() => this);
        }

        public void Visit(PersonData data)
        {
            FirstName = data.FirstName;
            LastName = data.LastName;
            UserName = data.UserName;
        }

        public void Visit(PersistablePersonData data)
        {
            Id = data.PersonKey?.Identifier ?? 0;
        }
    }
}
