using TMS.Layer.ModelObjects;

namespace TMS.ModelLayer.People
{
    public class Person : AggregateRoot<IPersonElement, IPersonVisitor>, IPersonElement
    {
        public Person(params IPersonElement[] elements) : base(elements)
        {
        }
    }
}
