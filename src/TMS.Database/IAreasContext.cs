using System.Collections.Generic;
using TMS.Database.Entities.Areas;

namespace TMS.Database
{
    public interface IAreasContext
    {
        IEnumerable<AreaEntity> Areas { get; }
    }
}
