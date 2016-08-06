using System;

namespace TMS.ModelLayer.People
{
    public class FirstName : IPersonElement
    {
        private readonly string _value;

        public string Value => _value;

        public FirstName(string value)
        {
            _value = value;
        }

        public IPersonVisitor Accept(IPersonVisitor visitor) => visitor.Visit(this);
    }
}
