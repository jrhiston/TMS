using TMS.ModelLayer.People;

namespace TMS.ViewModelLayer.Models.People
{
    public class PersonPasswordHashViewModel : PersonVisitorBase
    {
        public string PasswordHash { get; private set; }

        public override IPersonVisitor Visit(PasswordHash passwordHash)
        {
            PasswordHash = passwordHash.Value;
            return this;
        }
    }
}
