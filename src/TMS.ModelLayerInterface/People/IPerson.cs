using TMS.Layer.ModelObjects;
using TMS.Layer.Visitors;
using TMS.ModelLayerInterface.People.Data;

namespace TMS.ModelLayerInterface.People
{
    public interface IPerson : IModelObject<IVisitor<PersonData>, PersonData>
    {
    }
}
