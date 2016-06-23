using TMS.Layer.ModelObjects;

namespace TMS.Layer.Persistence
{
    public interface IWriter<TModelObject, TModelObjectKey> where TModelObjectKey : IModelKey
    {
        TModelObjectKey Save(TModelObject objectToSave);

        void Delete(TModelObjectKey objectToDeleteKey);
    }
}
