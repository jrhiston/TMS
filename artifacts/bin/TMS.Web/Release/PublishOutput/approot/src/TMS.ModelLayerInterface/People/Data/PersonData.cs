using TMS.Layer.Data;

namespace TMS.ModelLayerInterface.People.Data
{
    public class PersonData : IData
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
    }
}
