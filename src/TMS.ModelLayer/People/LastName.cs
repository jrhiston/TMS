using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TMS.ModelLayer.People
{
    public class LastName : IPersonElement
    {
        private readonly string _value;

        public string Value => _value;

        public LastName(string value)
        {
            _value = value;
        }

        public IPersonVisitor Accept(IPersonVisitor visitor) => visitor.Visit(this);
    }
}
