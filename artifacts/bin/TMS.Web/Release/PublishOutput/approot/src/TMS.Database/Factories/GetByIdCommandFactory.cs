using TMS.Database.Commands;
using TMS.Database.Contexts;
using TMS.Database.Entities;
using TMS.Layer.Conversion;
using TMS.Layer.Factories;
using TMS.Layer.ModelObjects;
using TMS.Layer.Repositories;

namespace TMS.Database.Factories
{
    public class GetByIdCommandFactory<TModelObject, TEntityType> : IEntityQueryFactory<IQueryCommand<IModelKey, TModelObject>, TEntityType> where TEntityType : class, IEntityWithId
    {
        private readonly MainContext _mainContext;
        private readonly IConverter<TEntityType, TModelObject> _entityConverter;

        public GetByIdCommandFactory(MainContext mainContext, IConverter<TEntityType, TModelObject> entityConverter)
        {
            _mainContext = mainContext;
            _entityConverter = entityConverter;
        }

        public IQueryCommand<IModelKey, TModelObject> Create() => new GetByIdCommand<TEntityType, TModelObject>(_mainContext, _entityConverter);
    }
}
