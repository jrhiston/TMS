using System.Collections.Generic;
using TMS.Layer;
using TMS.ModelLayerInterface.Activities.Data;
using TMS.ModelLayerInterface.Activities.Decorators;

namespace TMS.RepositoryLayerInterface.CommandObjects.Activities
{
    public interface IListActivitiesCommand
    {
        IList<Maybe<IPersistableActivity>> ExecuteCommand(ActivityFilterData activityFilter);
    }
}
