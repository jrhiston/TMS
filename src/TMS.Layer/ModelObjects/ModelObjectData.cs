using TMS.Layer.Data;

namespace TMS.Layer.ModelObjects
{
    public abstract class ModelObjectData<TData> where TData : IData
    {
        protected abstract TData GetData();
    }
}
