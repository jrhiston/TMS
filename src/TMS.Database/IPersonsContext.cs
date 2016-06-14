using System.Collections.Generic;
using TMS.Database.Entities.People;

namespace TMS.Database
{
    public interface IPersonsContext
    {
        IEnumerable<PersonEntity> Persons { get; }
    }
}
