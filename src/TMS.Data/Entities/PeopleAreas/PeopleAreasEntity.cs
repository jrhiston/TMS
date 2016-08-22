using System.ComponentModel.DataAnnotations.Schema;
using TMS.Data.Entities.Areas;
using TMS.Data.Entities.People;

namespace TMS.Data.Entities.PeopleAreas
{
    [Table("PersonArea")]
    public class PeopleAreasEntity
    {
        public long PersonId { get; set; }
        public PersonEntity Person { get; set; }

        public long AreaId { get; set; }
        public AreaEntity Area { get; set; }
    }
}
