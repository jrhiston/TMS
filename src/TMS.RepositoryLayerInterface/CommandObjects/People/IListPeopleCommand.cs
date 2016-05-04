using System.Collections.Generic;
using TMS.LayerInterface.People;
using TMS.ModelLayerInterface.People;
using TMS.ModelLayerInterface.People.Decorators;

namespace TMS.RepositoryLayerInterface.CommandObjects.People
{
    public interface IListPeopleCommand
    {
        IList<IPersistablePerson> ExecuteCommand(PersonFilterData personFilter);
    }
}
