using System;
using System.Collections;
using System.Collections.Generic;
using TMS.ModelLayer.Areas;
using TMS.ModelLayer.People;
using TMS.ModelLayer.Tags;

namespace TMS.ModelLayer.Activities
{
    public abstract class ActivityVisitorBase : IActivityVisitor
    {
        public virtual IActivityVisitor Visit(ActivityKey data) => this;
        public virtual IActivityVisitor Visit(CreationDate data) => this;
        public virtual IActivityVisitor Visit(PersonKey data) => this;
        public virtual IActivityVisitor Visit(Tag data) => this;
        public virtual IActivityVisitor Visit(Description data) => this;
        public virtual IActivityVisitor Visit(Name data) => this;
        public virtual IActivityVisitor Visit(AreaKey data) => this;

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public virtual IEnumerator<IActivityElement> GetEnumerator() { yield break; }
    }
}
