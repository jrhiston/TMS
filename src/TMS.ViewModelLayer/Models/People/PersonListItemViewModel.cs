using TMS.ModelLayer.People;

namespace TMS.ViewModelLayer.Models.People
{
    public class PersonListItemViewModel : PersonVisitorBase
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }

        public override IPersonVisitor Visit(PersonKey personKey)
        {
            Id = personKey.Identifier;
            return this;
        }

        public override IPersonVisitor Visit(UserName userName)
        {
            UserName = userName.Value;
            return this;
        }

        public override IPersonVisitor Visit(FirstName firstName)
        {
            FirstName = firstName.Value;
            return this;
        }

        public override IPersonVisitor Visit(LastName lastName)
        {
            LastName = lastName.Value;
            return this;
        }
    }
}
