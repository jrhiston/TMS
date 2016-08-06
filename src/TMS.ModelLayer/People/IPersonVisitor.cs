using System.Collections.Generic;

namespace TMS.ModelLayer.People
{
    public interface IPersonVisitor : IEnumerable<IPersonElement>
    {
        IPersonVisitor Visit(PersonKey personKey);
        IPersonVisitor Visit(FirstName firstName);
        IPersonVisitor Visit(LastName lastName);
        IPersonVisitor Visit(UserName userName);
        IPersonVisitor Visit(PasswordHash passwordHash);
    }
}