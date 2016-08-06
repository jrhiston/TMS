using System.Collections;
using System.Collections.Generic;
using TMS.ModelLayer.Activities;
using TMS.ModelLayer.People;

namespace TMS.ModelLayer.Areas
{
    public class AreaVisitorBase : IAreaVisitor
    {
        public virtual IAreaVisitor Visit(Description description) => this;
        public virtual IAreaVisitor Visit(Activity activity) => this;
        public virtual IAreaVisitor Visit(PersonKey personKey) => this;
        public virtual IAreaVisitor Visit(CreationDate creationDate) => this;
        public virtual IAreaVisitor Visit(Name name) => this;
        public virtual IAreaVisitor Visit(AreaKey areaKey) => this;

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public virtual IEnumerator<IAreaElement> GetEnumerator()
        {
            yield break;
        }
    }
}
