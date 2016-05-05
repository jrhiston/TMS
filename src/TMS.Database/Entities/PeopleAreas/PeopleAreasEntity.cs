using TMS.Database.Entities.Areas;
using TMS.Database.Entities.People;

namespace TMS.Database.Entities.PeopleAreas
{
    public class PeopleAreasEntity
    {
        public long PersonId { get; set; }
        public PersonEntity Person { get; set; }

        public long AreaId { get; set; }
        public AreaEntity Area { get; set; }
    }
}
