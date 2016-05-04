using TMS.Layer.Data;

namespace TMS.ModelLayerInterface.People.Data
{
    public class PersistablePersonData : IData
    {
        public IPersonKey PersonKey { get; set; }
        public string PasswordHash { get; set; }
    }
}
