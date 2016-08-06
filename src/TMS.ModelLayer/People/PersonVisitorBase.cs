using System.Collections;
using System.Collections.Generic;

namespace TMS.ModelLayer.People
{
    public class PersonVisitorBase : IPersonVisitor
    {
        public virtual IPersonVisitor Visit(LastName lastName) => this;
        public virtual IPersonVisitor Visit(PasswordHash passwordHash) => this;
        public virtual IPersonVisitor Visit(UserName userName) => this;
        public virtual IPersonVisitor Visit(FirstName firstName) => this;
        public virtual IPersonVisitor Visit(PersonKey personKey) => this;

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public virtual IEnumerator<IPersonElement> GetEnumerator()
        {
            yield break;
        }
    }
}
