using System;
using System.Linq;
using TMS.Layer.ModelObjects;
using TMS.Layer.Repositories;

namespace TMS.Layer.Persistence
{
    public class Writer<TModelObject, TModelObjectKey> : IWriter<TModelObject, TModelObjectKey> where TModelObjectKey : IModelKey
    {
        private readonly IPersistableRepository<TModelObject, TModelObjectKey> _persistableRepository;

        public Writer(IPersistableRepository<TModelObject, TModelObjectKey> persistableRepository)
        {
            _persistableRepository = persistableRepository;
        }

        public TModelObjectKey Save(TModelObject objectToSave)
        {
            var value = _persistableRepository.Save(objectToSave);

            if (!value.Any())
            {
                throw new InvalidOperationException("Failed to save.");
            }

            return value.FirstOrDefault();
        }

        public void Delete(TModelObjectKey objectToDeleteKey) => _persistableRepository.Delete(objectToDeleteKey);
    }
}
